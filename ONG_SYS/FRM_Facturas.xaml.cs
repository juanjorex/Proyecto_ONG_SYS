using Capa_de_Negocios_ONG_SYS;
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

namespace ONG_SYS
{
    /// <summary>
    /// Interaction logic for FRM_Facturas.xaml
    /// </summary>
    public partial class FRM_Facturas : Window
    {
        private CN_facturacion objetoCN = new CN_facturacion();
        public FRM_Facturas()
        {
            InitializeComponent();
        }

        private void btn_Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Principal_facturacion paginaanteriorP = new FRM_Principal_facturacion();
            paginaanteriorP.ShowDialog();
            this.Close();
        }

        private void dgv_facturas_Loaded(object sender, RoutedEventArgs e)
        {
            dgv_facturas.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objetoCN.MostrarFacturas() });
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            CN_facturacion objec1 = new CN_facturacion();

            dgv_facturas.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec1.BuscarFactura(tstBusf.Text) });
        }

        private void btn_Regresar_Copy_Click(object sender, RoutedEventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.ShowDialog();
            this.Close();
        }
    }
}
