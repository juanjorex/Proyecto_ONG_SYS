using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_de_Negocios_ONG_SYS;
namespace ONG_SYS
{
    /// <summary>
    /// Lógica de interacción para Facturacion.xaml
    /// </summary>
    public partial class Facturacion : Window
    {
        public bool variableCF = false;
        public bool esProducto = false;
        public string idF = null;
        public string idCliente = null;
        public string idFactura = null;

        CN_facturacion factura = new CN_facturacion();
        CN_Clientes clientes = new CN_Clientes();
        FRM_Buscar_Producto buscarProducto;
        FRM_Buscar_Servicios buscar_Servicio;
        FRM_NuevoCliente nuevoCliente;
        DataTable detalleFactura;
        public Facturacion()
        {
            InitializeComponent();
            buscarProducto = new FRM_Buscar_Producto(this);
            buscar_Servicio = new FRM_Buscar_Servicios(this);
        }

        private void MostrarDetalle()
        {

            DT_Facturacion.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = factura.MostrarDetalle() });

        }
        //private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    MostrarDetalle();
        //}

        private void btnSel_Click_1(object sender, RoutedEventArgs e)
        {
            ListaClientesFactura listaC = new ListaClientesFactura(this);

            listaC.ShowDialog();
        }

        private void btnRs_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Principal_facturacion paginaanteriorP = new FRM_Principal_facturacion();
            paginaanteriorP.ShowDialog();
            this.Close();
        }




        //private void btnCF_Click(object sender, RoutedEventArgs e)
        //{

        //    if (variableCF == false)
        //    {
        //        FMR_AUTENTICACION au = new FMR_AUTENTICACION();
        //        try
        //        {
        //            objecF.CrearFactura(idF, au.valorid);
        //            MessageBox.Show("Se ha creado una factura");



        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("No es posible crear la factura por :" + ex);

        //        }



        //    }
        //    else { MessageBox.Show("Verifique sus datos"); }

        //}

        private void btnCF_Click_1(object sender, RoutedEventArgs e)
        {
            var idUsuario = FMR_AUTENTICACION.GetInstancia();
            int id = factura.CrearFactura(idCliente, idUsuario.valorid);
            idFactura = id.ToString();
            txt_idFactura.Text = idFactura;
            MessageBox.Show("Se creó la factura, proceda a ingresar el detalle");
            btn_AgregarProducto.IsEnabled = true;
            btn_agregarServicio.IsEnabled = true;
            btn_agregarDetalle.IsEnabled = true;
            btnRs_Copy1.IsEnabled = true;
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            string identificacion = txtCedula.Text;
            bool esCedula = identificacion.Length == 10;
            if (esCedula)
            {
                identificacion = identificacion + "001";
            }
            if (VERIFICA_IDENTIFICACION.VerificaIdentificacion(identificacion) == false || identificacion.Length < 13)
            {
                MessageBox.Show("Verifique identificación del cliente");
                return;
            }
            else
            {
                DataTable respuesta = clientes.BuscarPorCedula(txtCedula.Text);
                if (respuesta.Rows.Count > 0)
                {
                    var fila = respuesta.Rows[0].ItemArray;
                    idCliente = fila[0].ToString();
                    txtNombre.Text = fila[1].ToString();
                    txtTelefono.Text = fila[3].ToString();
                    txtDireccion.Text = fila[4].ToString();
                    txtCorreo.Text = fila[5].ToString();

                    

                }
                else
                {
                    MessageBox.Show("Cliente no registrado, proceda a ingresar sus datos");
                    nuevoCliente = new FRM_NuevoCliente(this);
                    if (esCedula)
                    {
                        nuevoCliente.cmb_tipocliente.SelectedIndex = 0;
                    }
                    else
                    {
                        nuevoCliente.cmb_tipocliente.SelectedIndex = 1;
                    }
                    nuevoCliente.TXT_IDENTIFICACION_CLIENTE.Text = txtCedula.Text;
                    nuevoCliente.ShowDialog();
                }
                btnCF.IsEnabled = true;
                

                
            }
        }

        private void txtCedula_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void btn_AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            buscarProducto = new FRM_Buscar_Producto(this);
            buscarProducto.ShowDialog();
        }

        private void btn_agregarServicio_Click(object sender, RoutedEventArgs e)
        {
            buscar_Servicio = new FRM_Buscar_Servicios(this);
            buscar_Servicio.ShowDialog();
        }

        private void txt_cantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void btn_agregarDetalle_Click(object sender, RoutedEventArgs e)
        {

            if (esProducto)
            {
                try
                {
                    factura.AgregarProducto(buscarProducto.idProducto, idFactura, txt_cantidad.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No hay suficientes productos en stock");
                }
            }
            else
            {
                factura.AgregarServicio(buscar_Servicio.idServicio, idFactura, txt_cantidad.Text);
            }
            LlenarTotales();
            LLenarDetalle();
        }

        private void LlenarTotales()
        {
            DataTable dt = factura.ObtenerDatosDeLaFactura(idFactura);
            var fila = dt.Rows[0].ItemArray;
            txt_subtotal.Text = Convert.ToDecimal(fila[7]).ToString("#.##");
            txt_iva.Text = Convert.ToDecimal(fila[8]).ToString("#.##");
            txt_total.Text = Convert.ToDecimal(fila[9]).ToString("#.##");
        }

        private void LLenarDetalle()
        {
            DT_Facturacion.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = factura.ObtenerDetalleDeLaFactura(idFactura) });
        }

        private void btnRs_Copy1_Click(object sender, RoutedEventArgs e)
        {

            Reporte reporte = new Reporte();
            reporte.ShowDialog();
            this.Close();





        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnCF.IsEnabled = false;
            btn_AgregarProducto.IsEnabled = false;
            btn_agregarServicio.IsEnabled = false;
            btn_agregarDetalle.IsEnabled = false;
            btnRs_Copy1.IsEnabled = false;
        }
    }
}
