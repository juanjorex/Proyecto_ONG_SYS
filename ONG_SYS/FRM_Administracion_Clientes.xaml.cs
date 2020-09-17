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
using Capa_de_Negocios_ONG_SYS;
using System.Data;


namespace ONG_SYS
{
    /// <summary>
    /// Lógica de interacción para FRM_Administracion_Clientes.xaml
    /// </summary>
    public partial class FRM_Administracion_Clientes : Window
    {
        private int idCliente = 0;
        CN_Clientes objetoCN = new CN_Clientes();
        public FRM_Administracion_Clientes()
        {
            InitializeComponent();
        }

        private void btn_Regresar_P_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Principal_Cliente paginaanteriorP = new FRM_Principal_Cliente();
            paginaanteriorP.ShowDialog();
            this.Close();
        }

        private void dgvCLIENTES_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dgvCLIENTES.SelectedItem as DataRowView;
            if (dgvCLIENTES.SelectedItem != null)
            {
            }
            if (rowView != null)
            {
                idCliente = Convert.ToInt32(rowView[0].ToString());
                TXT_Nombre_Cliente.Text = rowView[1].ToString().Split(' ')[0];
                TXT_APELLIDO_C.Text = rowView[1].ToString().Split(' ')[1];
                
                if (rowView[2].ToString().Length == 10)
                {
                    cmb_TipoCliente.SelectedIndex = 0;
                }
                else 
                {
                    cmb_TipoCliente.SelectedIndex = 1;
                }
                TXT_IDENTIFICACION_C.Text = rowView[2].ToString();

                TXT_Telefono.Text = rowView[3].ToString();

                TXT_direccion_C.Text = rowView[4].ToString();
                TXT_Correo.Text = rowView[5].ToString();
                
                btn_ACTUALIZAR_S.IsEnabled = true;
                btn_ELIMINAR_P.IsEnabled = true;
                btn_Regresar_P.IsEnabled = true;
                TXT_IDENTIFICACION_C.IsEnabled = false;
                TXT_Nombre_Cliente.IsEnabled = false;
                TXT_APELLIDO_C.IsEnabled = false;
                cmb_TipoCliente.IsEnabled = false;
                TXT_direccion_C.IsEnabled = true;
                TXT_Telefono.IsEnabled = true;
                TXT_Correo.IsEnabled = true;

            }
            else
            {
                btn_ACTUALIZAR_S.IsEnabled = false;
                btn_ELIMINAR_P.IsEnabled = false;
                btn_Regresar_P.IsEnabled = true;
                TXT_IDENTIFICACION_C.IsEnabled = false;
                TXT_Nombre_Cliente.IsEnabled = false;
                TXT_APELLIDO_C.IsEnabled = false;
                cmb_TipoCliente.IsEnabled = false;
                TXT_direccion_C.IsEnabled = false;
                TXT_Telefono.IsEnabled = false;
                TXT_Correo.IsEnabled = false;

            }
        }

        private void MostrarCliente()
        {
            CN_Clientes objec = new CN_Clientes();
            dgvCLIENTES.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec.MostrarTipoProducto() });
        }
        private void dgvCLIENTES_Loaded(object sender, RoutedEventArgs e)
        {
            //MostrarCliente();
        }

        private void limpiarForm()
        {
            TXT_IDENTIFICACION_C.Clear();
            TXT_Nombre_Cliente.Clear();
            TXT_APELLIDO_C.Clear();
            cmb_TipoCliente.Text = "";
            TXT_direccion_C.Clear();
            TXT_Telefono.Clear();
            TXT_Correo.Clear();
        }

        private void btn_ELIMINAR_C_Click(object sender, RoutedEventArgs e)
        {
            if (dgvCLIENTES.SelectedItem == null)
            {
                MessageBox.Show("Verifique si se selecciono algún campo");


            }
            else
            {

                objetoCN.EliminarCliente(idCliente);
                MessageBox.Show("Se ha eliminado correctamente");
                //MostrarCliente();
                limpiarForm();
            }
        }

        private void TXT_BUSCAR_CLIENTE_TextChanged(object sender, TextChangedEventArgs e)
        {
            //CN_Clientes objetoCN = new CN_Clientes();
            //dgvCLIENTES.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objetoCN.BuscarC(TXT_BUSCAR_CLIENTE.Text) });
        }



        private void btn_ACTUALIZAR_S_Click(object sender, RoutedEventArgs e)
        {
            string identificacion = TXT_IDENTIFICACION_C.Text;
            if (cmb_TipoCliente.SelectedIndex == 0)
            {
                identificacion = identificacion + "001";
            }

            if (VERIFICA_IDENTIFICACION.VerificaIdentificacion(identificacion) == false || identificacion.Length < 13)
            {
                MessageBox.Show("Verifique identificación del cliente");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Nombre_Cliente.Text))
            {
                MessageBox.Show("Verifique que el campo Nombre del cliente se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_IDENTIFICACION_C.Text))
            {
                MessageBox.Show("Verifique que el campo de identificación se encuentre lleno");
                return;

            }
            else if (cmb_TipoCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de cliente");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_APELLIDO_C.Text))
            {
                MessageBox.Show("Verifique que el campo apellido se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_direccion_C.Text))
            {
                MessageBox.Show("Verifique que el campo Dirección se encuentre lleno");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_direccion_C.Text))
            {
                MessageBox.Show("Verifique que el campo Teléfono se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Correo.Text))
            {
                MessageBox.Show("Verifique que el campo de correo electrónico se encuentre lleno");
                return;
            }
            else if (VERIFICA_IDENTIFICACION.VerificaIdentificacion(identificacion) == true)
            {
                try
                {
                    objetoCN.EditarCliente(idCliente, cmb_TipoCliente.SelectedIndex + 1, TXT_Nombre_Cliente.Text, TXT_APELLIDO_C.Text, TXT_IDENTIFICACION_C.Text, TXT_Telefono.Text, TXT_direccion_C.Text, TXT_Correo.Text);
                    MessageBox.Show("Cliente actualizado correctamente!","",MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    

                    limpiarForm();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error Producido por: " + ex);
                }
            }
        }

        private void cmb_TipoCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TXT_IDENTIFICACION_C.Clear();
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                TXT_IDENTIFICACION_C.MaxLength = 10;
            }
            else
            {
                TXT_IDENTIFICACION_C.MaxLength = 13;
            }
        }

        private void BTN_BuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            CN_Clientes objetoCN = new CN_Clientes();
            dgvCLIENTES.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objetoCN.BuscarC(TXT_BUSCAR_CLIENTE.Text) });
        }

        private void btn_ELIMINAR_P_Click(object sender, RoutedEventArgs e)
        {
            if (dgvCLIENTES.SelectedItem == null)
            {
                MessageBox.Show("Verifique si se selecciono algún campo");


            }
            else
            {
                try
                {
                    objetoCN.EliminarCliente(idCliente);
                    MessageBox.Show("Se ha eliminado correctamente");
                    dgvCLIENTES.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = new DataTable() });
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar al cliente porque tiene facturas a su nombre");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TXT_IDENTIFICACION_C.IsEnabled=false;
            TXT_Nombre_Cliente.IsEnabled = false;
            TXT_APELLIDO_C.IsEnabled = false;
            cmb_TipoCliente.IsEnabled = false;
            TXT_direccion_C.IsEnabled = false;
            TXT_Telefono.IsEnabled = false;
            TXT_Correo.IsEnabled = false;
        }

        private void TXT_BUSCAR_CLIENTE_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_BUSCAR_CLIENTE.Text)) {
                TXT_BUSCAR_CLIENTE.Visibility = System.Windows.Visibility.Collapsed;
                Waterfall_buscar_c.Visibility = System.Windows.Visibility.Visible;
            
            }
        }

        private void Waterfall_buscar_c_GotFocus(object sender, RoutedEventArgs e)
        {
            Waterfall_buscar_c.Visibility = System.Windows.Visibility.Collapsed;
            TXT_BUSCAR_CLIENTE.Visibility = System.Windows.Visibility.Visible;
            TXT_BUSCAR_CLIENTE.Focus();
        }
    }
}
