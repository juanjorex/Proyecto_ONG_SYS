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
namespace ONG_SYS
{
    /// <summary>
    /// Lógica de interacción para FRM_Administracion_Proveedores.xaml
    /// </summary>
    public partial class FRM_Administracion_Proveedores : Window
    {
        private string idProveedor = null;
        CN_Proveedores objetoCN = new CN_Proveedores();

        public FRM_Administracion_Proveedores()
        {
            InitializeComponent();
            ListarProvincia();
        }

        private void MostrarProveedores()
        {
            CN_Proveedores objec = new CN_Proveedores();
            dgvProveedores.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec.mostrarProveedores() });

        }

        public void ListarProvincia()
        {
            CN_Proveedores objCNPro = new CN_Proveedores();
            cmb_Provincia.ItemsSource = objCNPro.GetProvincias();
            this.cmb_Provincia.DisplayMemberPath = "Nombre";
            this.cmb_Provincia.SelectedValuePath = "Id";
        }

        private void limpiarForm()
        {
            TXT_ID_PROVEEDOR.Clear();
            TXT_Nombre_Proveedor_P.Clear();
            TXT_RUC.Clear();
            cmb_Provincia.Text = "";
            TXT_Ciudad.Clear();
            TXT_direccion.Clear();
            TXT_Telefono.Clear();
        }







        private void btn_Regresar_P_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_MENU_PRINCIPAL paginaanteriorP = new FRM_MENU_PRINCIPAL();
            paginaanteriorP.ShowDialog();
            this.Close();
        }

        private void TXT_RUC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void TXT_Telefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void TXT_Ciudad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }
        }

        private void btn_Agregar_NS_Click(object sender, RoutedEventArgs e)
        {
            CN_Proveedores NPro = new CN_Proveedores();

            if (VERIFICA_IDENTIFICACION.VerificaIdentificacion(TXT_RUC.Text) == false || TXT_RUC.Text.Length < 13)
            {
                MessageBox.Show("Verifique el ruc del proveedor");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Nombre_Proveedor_P.Text))
            {
                MessageBox.Show("Verifique que el campo Nombre del proveedor se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_RUC.Text))
            {
                MessageBox.Show("Verifique que el campo RUC se encuentre lleno");
                return;

            }
            else if (cmb_Provincia.SelectedIndex == -1)
            {
                MessageBox.Show("Verifique que se haya escogido una Provincia");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Ciudad.Text))
            {
                MessageBox.Show("Verifique que el campo Ciudad se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_direccion.Text))
            {
                MessageBox.Show("Verifique que el campo Dirección se encuentre lleno");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_Telefono.Text))
            {
                MessageBox.Show("Verifique que el campo Teléfono se encuentre lleno");
                return;

            }
            else if (VERIFICA_IDENTIFICACION.VerificaIdentificacion(TXT_RUC.Text) == true)
            {
                NPro.InsertarProv(TXT_Nombre_Proveedor_P.Text, TXT_RUC.Text, Convert.ToInt32(cmb_Provincia.SelectedValue), TXT_Ciudad.Text, TXT_direccion.Text, TXT_Telefono.Text);
                MessageBox.Show("Proveedor Ingresado Correctamente");
                //MostrarProveedores();
                limpiarForm();
                return;
            }
        }

        private void btn_ELIMINAR_P_Click(object sender, RoutedEventArgs e)
        {

            if (dgvProveedores.SelectedItem == null)
            {
                MessageBox.Show("Verifique si se selecciono algún campo");


            }
            else
            {
                try
                {
                    objetoCN.EliminarProv(idProveedor);
                    MessageBox.Show("Se ha eliminado correctamente");
                    dgvProveedores.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = new DataTable() });
                    limpiarForm();
                    //MostrarProveedores();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar al proveedor porque tiene productos que lo incluyen");
                }
            }
        }

        private void btn_ACTUALIZAR_S_Click(object sender, RoutedEventArgs e)
        {
            if (VERIFICA_IDENTIFICACION.VerificaIdentificacion(TXT_RUC.Text) == false || TXT_RUC.Text.Length < 13)
            {
                MessageBox.Show("Verifique el ruc del proveedor");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Nombre_Proveedor_P.Text))
            {
                MessageBox.Show("Verifique que el campo Nombre del proveedor se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_RUC.Text))
            {
                MessageBox.Show("Verifique que el campo RUC se encuentre lleno");
                return;

            }
            else if (cmb_Provincia.SelectedIndex == -1)
            {
                MessageBox.Show("Verifique que se haya escogido una Provincia");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_Ciudad.Text))
            {
                MessageBox.Show("Verifique que el campo Ciudad se encuentre lleno");
                return;

            }
            else if (string.IsNullOrEmpty(TXT_direccion.Text))
            {
                MessageBox.Show("Verifique que el campo Dirección se encuentre lleno");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_Telefono.Text))
            {
                MessageBox.Show("Verifique que el campo Teléfono se encuentre lleno");
                return;

            }
            else if (dgvProveedores.SelectedItem == null)
            {
                MessageBox.Show("Verifique que algun dato se encuentre seleccionado");
                return;

            }
            else if (VERIFICA_IDENTIFICACION.VerificaIdentificacion(TXT_RUC.Text) == true)
            {
                objetoCN.EditarProd(TXT_Nombre_Proveedor_P.Text, TXT_RUC.Text, Convert.ToInt32(cmb_Provincia.SelectedValue), TXT_Ciudad.Text, TXT_direccion.Text, TXT_Telefono.Text, idProveedor);
                MessageBox.Show("Se actualizo correctamente");

               // MostrarProveedores();
                limpiarForm();
                btn_Agregar_NS.IsEnabled = true;
                btn_ACTUALIZAR_S.IsEnabled = false;
                btn_ELIMINAR_P.IsEnabled = false;
                btn_Regresar_P.IsEnabled = true;
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dgvProveedores.SelectedItem as DataRowView;
            if (dgvProveedores.SelectedItem != null)
            {
            }
            if (rowView != null)
            {
                cmb_Provincia.Text = rowView[3].ToString();

                TXT_Nombre_Proveedor_P.Text = rowView[1].ToString();
                TXT_RUC.Text = rowView[2].ToString();
                TXT_Ciudad.Text = rowView[4].ToString();
                TXT_direccion.Text = rowView[5].ToString();
                TXT_Telefono.Text = rowView[6].ToString();
                TXT_ID_PROVEEDOR.Text = rowView[0].ToString();
                idProveedor = rowView[0].ToString();

                btn_Agregar_NS.IsEnabled = false;
               btn_ACTUALIZAR_S.IsEnabled = true;
                btn_ELIMINAR_P.IsEnabled = true;
                btn_Regresar_P.IsEnabled = true;

                TXT_ID_PROVEEDOR.IsEnabled = false;
                TXT_Nombre_Proveedor_P.IsEnabled = false;
                TXT_RUC.IsEnabled = false;
                cmb_Provincia.IsEnabled = true;
                TXT_Ciudad.IsEnabled = true;
                TXT_direccion.IsEnabled = true;
                TXT_Telefono.IsEnabled = true;

            }
            else
            {
                btn_Agregar_NS.IsEnabled = true;
                btn_ACTUALIZAR_S.IsEnabled = false;
                btn_ELIMINAR_P.IsEnabled = false;
                btn_Regresar_P.IsEnabled = true;

                TXT_ID_PROVEEDOR.IsEnabled = false;
                TXT_Nombre_Proveedor_P.IsEnabled = true;
                TXT_RUC.IsEnabled = true;
                cmb_Provincia.IsEnabled = true;
                TXT_Ciudad.IsEnabled = true;
                TXT_direccion.IsEnabled = true;
                TXT_Telefono.IsEnabled = true;

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn_Agregar_NS.IsEnabled = true;
            btn_ACTUALIZAR_S.IsEnabled = false;
            btn_ELIMINAR_P.IsEnabled = false;
            btn_Regresar_P.IsEnabled = true;

        }

        private void dgvProveedores_Loaded(object sender, RoutedEventArgs e)
        {
            //MostrarProveedores();
        }

        private void BTN_BuscarProveedor_Click(object sender, RoutedEventArgs e)
        {
            dgvProveedores.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objetoCN.Buscar(TXT_BUSCAR_Proveedor.Text) });
            limpiarForm();
        }

        private void TXT_BUSCAR_Proveedor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_BUSCAR_Proveedor.Text))
            {
                TXT_BUSCAR_Proveedor.Visibility = System.Windows.Visibility.Collapsed;
                Waterfall_TXT_BUSCAR_Proveedor.Visibility = System.Windows.Visibility.Visible;

            }
        }

        private void Waterfall_TXT_BUSCAR_Proveedor_GotFocus(object sender, RoutedEventArgs e)
        {
            Waterfall_TXT_BUSCAR_Proveedor.Visibility = System.Windows.Visibility.Collapsed;
            TXT_BUSCAR_Proveedor.Visibility = System.Windows.Visibility.Visible;
            TXT_BUSCAR_Proveedor.Focus();
        }
    }
}
