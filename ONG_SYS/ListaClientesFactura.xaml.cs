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
    /// Lógica de interacción para ListaClientesFactura.xaml
    /// </summary>
    public partial class ListaClientesFactura : Window
    {
        public ListaClientesFactura()
        {
            InitializeComponent();
        }
        //public ListaClientesFactura()
        //{
        //    InitializeComponent();
        //}
        //Variable que guardará el form
        private Facturacion padre;
        public string  VA=null;

        public ListaClientesFactura(Facturacion parametro)
        {
            InitializeComponent();

            //Asigno el parámetro a mi variable
            padre = parametro;
        }

        private void MostrarClientesF()
        {
            CN_Clientefacturacion objeccl = new CN_Clientefacturacion();
            DTC.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objeccl.MostrarClienteF() });

        }

        //private void DTC_Loaded(object sender, RoutedEventArgs e)
        //{
        //    MostrarClientes();
        //}

        //private void DTC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    if (DTC.SelectedItem != null)
        //    {
        //        //foreach (DataRow row in tbl.Rows)
        //        //{
        //        //    string dta = row["idtiposervicio"].ToString();
        //        //    string dtb = row["Nombreservicio"].ToString();
        //        //    string dtc = row["Valorservicio"].ToString();

        //        //    txtTS.Text = dta;
        //        //    txtNS.Text = dtb;
        //        //    txtVS.Text = dtc;
        //        //}

        //        DataGrid dataGrid = sender as DataGrid;
        //        DataRowView rowView = dataGrid.SelectedItem as DataRowView;
        //        try
        //        {
        //            if (rowView.Row != null)
        //            {
        //                //Facturacion fc = new Facturacion();

        //                string dt1 = rowView.Row[1].ToString(); /* 1st Column on selected Row */
        //                string dt2 = rowView.Row[2].ToString();
        //                string dt3 = rowView.Row[3].ToString();
        //                string dt4 = rowView.Row[4].ToString();
        //                string dt5 = rowView.Row[5].ToString();

        //                padre.txtNombre.Text = dt1;
        //                padre.txtCedula.Text = dt2;
        //                padre.txtTelefono.Text = dt3;
        //                padre.txtDireccion.Text = dt4;
        //                padre.txtCorreo.Text = dt5;

        //            }
        //            else
        //            {
        //                MessageBox.Show("Debe contener informacion");

        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("No puede seleccionar un campo vacio" + ex);


        //        }

        //    }
        //    else
        //    {

        //        //MessageBox.Show("Seleccione una fila!");
        //    }
        //}

        //private void btnAF_Click(object sender, RoutedEventArgs e)
        //{

        //    this.Hide();
        //    padre.ShowDialog();
        //}

        private void DTC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataRowView rowView = dataGrid.SelectedItem as DataRowView;
            try
            {
                if (rowView.Row != null)
                {
                    //Facturacion fc = new Facturacion();

                    string dt1 = rowView.Row[1].ToString(); /* 1st Column on selected Row */
                    string dt2 = rowView.Row[2].ToString();
                    string dt3 = rowView.Row[3].ToString();
                    string dt4 = rowView.Row[4].ToString();
                    string dt5 = rowView.Row[5].ToString();
                    string dt6 = rowView.Row[0].ToString();
                    VA = dt6;
                    padre.txtNombre.Text = dt1;
                    padre.txtCedula.Text = dt2;
                    padre.txtTelefono.Text = dt3;
                    padre.txtDireccion.Text = dt4;
                    padre.txtCorreo.Text = dt5;
                    padre.Show();

                }
                else
                {
                    MessageBox.Show("Debe contener informacion");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No puede seleccionar un campo vacio" + ex);


            }

        }

        private void DTC_Loaded(object sender, RoutedEventArgs e)
        {
            MostrarClientesF();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CN_Clientes objetoCN = new CN_Clientes();
            DTC.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objetoCN.BuscarC(txt_BuscaCliente.Text) });
        }
    }
}
