using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data;

using Capa_de_Negocios_ONG_SYS;
using System.Windows.Interop;
using System.Text.RegularExpressions;
using System.Threading;


namespace ONG_SYS
{
    /// <summary>
    /// Lógica de interacción para FRM_Administracion_Productos.xaml
    /// </summary>

    public partial class FRM_Administracion_Productos : Window
    {
        FRM_Buscar_Proveedor BUSCAR = new FRM_Buscar_Proveedor();
        private string idProducto = null;
        public string id = "";
        CN_Productos objetoCN = new CN_Productos();
        public FRM_Administracion_Productos()
        {
            InitializeComponent();
            ListarTipoProductos();
            BUSCAR = new FRM_Buscar_Proveedor(this);
        }

        private void btn_Regresar_P_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_MENU_PRINCIPAL paginaanteriorP = new FRM_MENU_PRINCIPAL();
            paginaanteriorP.ShowDialog();
            this.Close();
        }

        private void BTN_SeleccionarProveedor_Click(object sender, RoutedEventArgs e)

        {
            BUSCAR = new FRM_Buscar_Proveedor(this);
            BUSCAR.ShowDialog();

        }

        public void ListarTipoProductos()
        {
            CN_Productos objCNPro = new CN_Productos();
            cmb_tipo_producto.ItemsSource = objCNPro.GetTipoProductos();
            this.cmb_tipo_producto.DisplayMemberPath = "Tipo_de_Producto";
            this.cmb_tipo_producto.SelectedValuePath = "Id";
        }

        private void MostrarProductos()
        {
            CN_Productos objec = new CN_Productos();
            dgvProductos.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec.mostrarProductos() });

        }



        private void limpiarForm()
        {
            TXT_ID_PRODUCTO.Clear();
            TXT_Nombre_Producto.Clear();
            cmb_tipo_producto.Text = "";
            TXT_Nombre_Proveedor.Clear();
            TXT_Marca.Clear();
            TXT_valor_unitario.Clear();
            TXT_STOCK.Clear();
        }

        private void dgvProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dgvProductos.SelectedItem as DataRowView;
            if (dgvProductos.SelectedItem != null)
            {
            }
            if (rowView != null)
            {
                cmb_tipo_producto.Text = rowView[2].ToString();
                char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                TXT_Nombre_Producto.Text = rowView[1].ToString();
                TXT_Nombre_Proveedor.Text = rowView[3].ToString();
                TXT_Marca.Text = rowView[4].ToString();
                TXT_valor_unitario.Text = rowView[5].ToString().Replace(separator, ',');
                TXT_STOCK.Text = rowView[6].ToString();
                TXT_ID_PRODUCTO.Text = rowView[0].ToString();
                idProducto = rowView[0].ToString();
                BUSCAR.idProveedor = objetoCN.ObtenerProveedor(Convert.ToInt32(idProducto)).ToString();
                btn_Agregar_NP.IsEnabled = false;
                btn_ELIMINAR_P.IsEnabled = true;
                btn_Regresar_P.IsEnabled = true;
                btn_ACTUALIZAR_P.IsEnabled = true;
                TXT_ID_PRODUCTO.IsEnabled = false;
                TXT_Nombre_Producto.IsEnabled = false;
                cmb_tipo_producto.IsEnabled = false;
                TXT_Nombre_Proveedor.IsEnabled = false;
                TXT_Marca.IsEnabled = false;
                TXT_valor_unitario.IsEnabled = true;
                TXT_STOCK.IsEnabled = true;

            }
            else
            {
                btn_Agregar_NP.IsEnabled = true;
                btn_ELIMINAR_P.IsEnabled = false;
                btn_Regresar_P.IsEnabled = true;
                btn_ACTUALIZAR_P.IsEnabled = false;
                TXT_Nombre_Producto.IsEnabled = true;
                cmb_tipo_producto.IsEnabled = true;
                TXT_Nombre_Proveedor.IsEnabled = false;
                TXT_Marca.IsEnabled = true;
                TXT_valor_unitario.IsEnabled = true;
                TXT_STOCK.IsEnabled = true;


            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn_Agregar_NP.IsEnabled = true;
            btn_ELIMINAR_P.IsEnabled = false;
            btn_Regresar_P.IsEnabled = true;
            btn_ACTUALIZAR_P.IsEnabled = false;

        }


        private void dgvProductos_Loaded(object sender, RoutedEventArgs e)
        {
            // MostrarProductos();
        }

        private void btn_Agregar_NP_Click(object sender, RoutedEventArgs e)
        {
            CN_Productos NPro = new CN_Productos();

            if (string.IsNullOrEmpty(TXT_Nombre_Producto.Text))
            {
                MessageBox.Show("Verifique que el campo Nombre del Producto se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Nombre_Proveedor.Text))
            {
                MessageBox.Show("Verifique que se selecciono un Proveedor");
                return;

            }
            else if (cmb_tipo_producto.SelectedIndex == -1)
            {
                MessageBox.Show("Verifique que se haya escogido un Tipo de Producto");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Marca.Text))
            {
                MessageBox.Show("Verifique que el campo Marca se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_valor_unitario.Text))
            {
                MessageBox.Show("Verifique que se digito un valor unitario del producto");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_STOCK.Text))
            {
                MessageBox.Show("Verifique que se digito la cantidad en stock del producto");
                return;

            }
            else
            {
                char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                NPro.Insertar(TXT_Nombre_Producto.Text, Convert.ToInt32(cmb_tipo_producto.SelectedValue), Convert.ToInt32(BUSCAR.idProveedor), TXT_Marca.Text, TXT_valor_unitario.Text.Replace(',', separator), Convert.ToInt32(TXT_STOCK.Text));


                MessageBox.Show("Producto Ingresado Correctamente");
                dgvProductos.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = new DataTable() });
                limpiarForm();
                return;
            }
        }

        private void btn_ACTUALIZAR_P_Click(object sender, RoutedEventArgs e)
        {
            CN_Productos NPro = new CN_Productos();

            if (string.IsNullOrEmpty(TXT_Nombre_Producto.Text))
            {
                MessageBox.Show("Verifique que el campo Nombre del Producto se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Nombre_Proveedor.Text))
            {
                MessageBox.Show("Verifique que se selecciono un Proveedor");
                return;

            }
            else if (cmb_tipo_producto.SelectedIndex == -1)
            {
                MessageBox.Show("Verifique que se haya escogido un Tipo de Producto");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Marca.Text))
            {
                MessageBox.Show("Verifique que el campo Marca se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_valor_unitario.Text))
            {
                MessageBox.Show("Verifique que se digito un valor unitario del producto");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_STOCK.Text))
            {
                MessageBox.Show("Verifique que se digito la cantidad en stock del producto");
                return;

            }
            else
            {
                char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                NPro.Editar(TXT_Nombre_Producto.Text, Convert.ToInt32(cmb_tipo_producto.SelectedValue), Convert.ToInt32(BUSCAR.idProveedor), TXT_Marca.Text, TXT_valor_unitario.Text.Replace(',', separator), Convert.ToInt32(TXT_STOCK.Text), Convert.ToInt32(idProducto));


                MessageBox.Show("Producto Actualizado Correctamente");
                dgvProductos.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = new DataTable() });
                limpiarForm();
                btn_Agregar_NP.IsEnabled = true;
                return;
            }
        }

        private void btn_ELIMINAR_P_Click(object sender, RoutedEventArgs e)
        {
            if (dgvProductos.SelectedItem == null)
            {
                MessageBox.Show("Verifique si se selecciono algún campo");


            }
            else
            {

                objetoCN.Eliminar(idProducto);
                MessageBox.Show("Se ha eliminado correctamente");
                dgvProductos.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = new DataTable() });
                limpiarForm();
            }
        }

        private void TXT_valor_unitario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex _regex = new Regex(@"^[0-9]+(\,)?([0-9]{1,2})?$");
            TextBox textBox = sender as TextBox;
            bool handler = _regex.IsMatch(textBox.Text + e.Text);
            e.Handled = !handler;
        }

        private void TXT_STOCK_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void BTN_BuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            CN_Productos objec = new CN_Productos();
           dgvProductos.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec.buscarProductos(TXT_BUSCAR_P.Text) });
            limpiarForm();
        }


        private void TXT_BUSCAR_P_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_BUSCAR_P.Text))
            {
                TXT_BUSCAR_P.Visibility = System.Windows.Visibility.Collapsed;
                Waterfall_TXT_BUSCAR_P.Visibility = System.Windows.Visibility.Visible;

            }

        }

        private void Waterfall_TXT_BUSCAR_P_GotFocus(object sender, RoutedEventArgs e)
        {
            Waterfall_TXT_BUSCAR_P.Visibility = System.Windows.Visibility.Collapsed;
            TXT_BUSCAR_P.Visibility = System.Windows.Visibility.Visible;
            TXT_BUSCAR_P.Focus();
        }

        

    }

}
