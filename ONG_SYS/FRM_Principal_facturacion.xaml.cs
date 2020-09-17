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
    /// Lógica de interacción para FRM_Principal_facturacion.xaml
    /// </summary>
    public partial class FRM_Principal_facturacion : Window
    {
        public FRM_Principal_facturacion()
        {
            InitializeComponent();
        }

        private void BTN_Nuevo_Factura_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Facturacion paginaAC = new Facturacion();
            paginaAC.ShowDialog();
            this.Close();
        }

        private void btn_Administracion_Facturas_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Facturas paginaAC = new FRM_Facturas();
            paginaAC.ShowDialog();
            this.Close();
        }

        private void btn_regresar_AC_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_MENU_PRINCIPAL paginaanteriorP = new FRM_MENU_PRINCIPAL();
            paginaanteriorP.ShowDialog();
            this.Close();
        }
    }
}
