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
using System.Windows.Threading;

namespace ONG_SYS
{
    /// <summary>
    /// Lógica de interacción para FRM_MENU_PRINCIPAL.xaml
    /// </summary>
    public partial class FRM_MENU_PRINCIPAL : Window
    {
        public FRM_MENU_PRINCIPAL()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            LBLFECHA.Content = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            LBLhORA.Content = DateTime.Now.ToLongTimeString();
        }

        private void btn_Administracion_Productos_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Administracion_Productos paginaNuevoP = new FRM_Administracion_Productos();
            paginaNuevoP.ShowDialog();
            this.Close();
        }

        private void btn_Administracion_Servicios_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Administracion_de_servicios paginaNuevoP = new FRM_Administracion_de_servicios();
            paginaNuevoP.ShowDialog();
            this.Close();
        }


        private void btn_Salir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir del Sistema?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        /*
         * Reporte reporte = new Reporte();
                reporte.ShowDialog();
                this.Close();
         */
        private void btn_Administracion_Proveedores_Click(object sender, RoutedEventArgs e)
        {
           
                this.Hide();
               FRM_Administracion_Proveedores paginaNuevoP = new FRM_Administracion_Proveedores();
                paginaNuevoP.ShowDialog();
                this.Close();
            
        }

      

        private void BTN_Administracion_Clientes_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Principal_Cliente paginaAC = new FRM_Principal_Cliente();
            paginaAC.ShowDialog();
            this.Close();

        }

        private void btn_Administracion_Facturas_Click(object sender, RoutedEventArgs e)
        {
            FRM_Principal_facturacion fac = new FRM_Principal_facturacion();
            this.Hide();
            fac.ShowDialog();
        }

        private void btn_verFacturas_Click(object sender, RoutedEventArgs e)
        {
            FRM_Facturas reporte = new FRM_Facturas();
            reporte.ShowDialog();
            this.Close();
        }

        private void btn_generarFacturas_Click(object sender, RoutedEventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.ShowDialog();
            this.Close();
        }
    }
}
