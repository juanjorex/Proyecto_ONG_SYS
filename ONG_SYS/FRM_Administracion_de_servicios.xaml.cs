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
using System.Data.SqlClient;
using Capa_de_Negocios_ONG_SYS;
using System.Text.RegularExpressions;
using System.Threading;

namespace ONG_SYS
{
    /// <summary>
    /// Lógica de interacción para FRM_Administracion_de_servicios.xaml
    /// </summary>
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
   public partial class FRM_Administracion_de_servicios : Window
    {
        public FRM_Administracion_de_servicios()
        {
            InitializeComponent();
            btn_ACTUALIZAR_S.IsEnabled = false;
            btn_ELIMINAR_S.IsEnabled = false;
            btn_Agregar_NS.IsEnabled = true;
        }

        private void btn_Regresar_S_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_MENU_PRINCIPAL paginaanteriorP = new FRM_MENU_PRINCIPAL();
            paginaanteriorP.ShowDialog();
            this.Close();
        }
        CN_Servicios objCN = new CN_Servicios();
        private string idServicio = null;
        private bool Editar = false;
        //List<Servicios> LServ:






        public object DataSource { get; set; }


        //private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    MostrarServicios();
        //}

        private void MostrarServicios()
        {
            CN_Servicios objec = new CN_Servicios();
            dtGLS.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec.MostrarServ() });

        }
       

        private void limpiarAdministracionServicios()
        {
            // CBTipoServicio.Clear();

            TXT_Nombre_Servicio.Clear();
            TXT_valor_servicio.Clear();
            CBTipoServicio.Text = "";
        }

        

        private void btn_Agregar_NS_Click(object sender, RoutedEventArgs e)
        {
          
            try
            {
                objCN.InsertarServ(CBTipoServicio.SelectedIndex + 1, TXT_Nombre_Servicio.Text, TXT_valor_servicio.Text);
                MessageBox.Show("Se guardó correctamente");
               // MostrarServicios();
                limpiarAdministracionServicios();


            }
            catch (Exception ex)
            {
                MessageBox.Show("No es posible insertar los datos" + ex);

            }

        }

        private void btn_ACTUALIZAR_S_Click(object sender, RoutedEventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objCN.EditarServ(TXT_Nombre_Servicio.Text, TXT_valor_servicio.Text, CBTipoServicio.SelectedIndex + 1, idServicio);
                    MessageBox.Show("Se actualizo correctamente");

                    //MostrarServicios();

                    limpiarAdministracionServicios();
                    btn_Agregar_NS.IsEnabled = true;
                    btn_ELIMINAR_S.IsEnabled = false;
                    btn_ACTUALIZAR_S.IsEnabled = false;
                    CBTipoServicio.IsEnabled=true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ha hactualizado los dato por : " + ex);


                }


            }
        }

        private void btn_ELIMINAR_S_Click(object sender, RoutedEventArgs e)
        {

            if (dtGLS.SelectedItem != null)

            {
                objCN.EliminarServ(idServicio);
                MessageBox.Show("Se ha eliminado correctamente");
                dtGLS.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = new DataTable() });
                limpiarAdministracionServicios();
            }
            else
            {
                MessageBox.Show("Eliga un dato");
            }

        }

        
        private void TXT_BUSCAR_Servicio_KeyUp(object sender, KeyEventArgs e)
        {
            //para buscaaaaaaar
            
        }

        private void dtGLS_Loaded_1(object sender, RoutedEventArgs e)
        {
           // MostrarServicios();

        }

        private void dtGLS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtGLS.SelectedItem != null)
            {
                //foreach (DataRow row in tbl.Rows)
                //{
                //    string dta = row["idtiposervicio"].ToString();
                //    string dtb = row["Nombreservicio"].ToString();
                //    string dtc = row["Valorservicio"].ToString();

                //    txtTS.Text = dta;
                //    txtNS.Text = dtb;
                //    txtVS.Text = dtc;
                //}

                DataGrid dataGrid = sender as DataGrid;
                DataRowView rowView = dataGrid.SelectedItem as DataRowView;
                try
                {
                    if (rowView.Row != null)
                    {
                        string dt1 = rowView.Row[1].ToString(); /* 1st Column on selected Row */
                        string dt2 = rowView.Row[2].ToString();
                        string dt3 = rowView.Row[3].ToString();
                        string dto = rowView.Row[0].ToString();
                        //txtTS.Text = dt1;
                        char separator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        TXT_Nombre_Servicio.Text = dt1;
                        TXT_valor_servicio.Text = dt3.Replace(separator, ',');
                        idServicio = dto;
                        CBTipoServicio.SelectedIndex = objCN.ObtenerTipoDeServicio(Convert.ToInt32(idServicio)) - 1;
                        btn_ACTUALIZAR_S.IsEnabled = true;
                        btn_ELIMINAR_S.IsEnabled = true;
                        btn_Agregar_NS.IsEnabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Debe contener informacion");
                        btn_ACTUALIZAR_S.IsEnabled = false;
                        btn_ELIMINAR_S.IsEnabled = false;
                        btn_Agregar_NS.IsEnabled = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No puede seleccionar un campo vacio" + ex);


                }

            }
            else
            {

                //MessageBox.Show("Seleccione una fila!");
            }
        }


        private void BTN_BuscarProducto_Click(object sender, RoutedEventArgs e)
        {
            CN_Servicios objec1 = new CN_Servicios();

            
            dtGLS.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec1.BuscarS(TXT_BUSCAR_Servicio.Text) });
            limpiarAdministracionServicios();
        }

        private void TXT_valor_servicio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex _regex = new Regex(@"^[0-9]+(\,)?([0-9]{1,2})?$");
            TextBox textBox = sender as TextBox;
            bool handler = _regex.IsMatch(textBox.Text + e.Text);
            e.Handled = !handler;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn_ACTUALIZAR_S.IsEnabled = false;
            btn_ELIMINAR_S.IsEnabled = false;
            btn_Agregar_NS.IsEnabled = true;
        }

        private void Waterfall_TXT_BUSCAR_Servicio_GotFocus(object sender, RoutedEventArgs e)
        {
            Waterfall_TXT_BUSCAR_Servicio.Visibility = System.Windows.Visibility.Collapsed;
            TXT_BUSCAR_Servicio.Visibility = System.Windows.Visibility.Visible;
            TXT_BUSCAR_Servicio.Focus();
        }

        private void TXT_BUSCAR_Servicio_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TXT_BUSCAR_Servicio.Text))
            {
                TXT_BUSCAR_Servicio.Visibility = System.Windows.Visibility.Collapsed;
                Waterfall_TXT_BUSCAR_Servicio.Visibility = System.Windows.Visibility.Visible;

            }
        }
    }
}
