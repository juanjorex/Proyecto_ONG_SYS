using Capa_de_Negocios_ONG_SYS;
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
using System.Windows.Shapes;

namespace ONG_SYS
{
    /// <summary>
    /// Interaction logic for FRM_Buscar_Servicios.xaml
    /// </summary>
    public partial class FRM_Buscar_Servicios : Window
    {
        public string idServicio = null;
        public string nombreServicio = null;
        CN_Servicios objetoCN = new CN_Servicios();
        private Facturacion padre;
        public FRM_Buscar_Servicios(Facturacion padre)
        {
            InitializeComponent();
            this.padre = padre;
        }
        public FRM_Buscar_Servicios()
        {
            InitializeComponent();
        }

        private void MostrarServicios(string nombreServicio)
        {
            dgv_servicios.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objetoCN.BuscarS(nombreServicio) });
        }

        private void dgv_servicios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dgv_servicios.SelectedItem as DataRowView;
            if (rowView != null)
            {
                nombreServicio = rowView[1].ToString();
                idServicio = rowView[0].ToString();
                padre.txt_producto.Text = nombreServicio;
                padre.esProducto = false;
                padre.Show();
                this.Close();
            }
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            MostrarServicios(txt_nombreServicio.Text);
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
