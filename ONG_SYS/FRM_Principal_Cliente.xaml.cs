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
    /// Lógica de interacción para FRM_Principal_Cliente.xaml
    /// </summary>
    public partial class FRM_Principal_Cliente : Window
    {
        public FRM_Principal_Cliente()
        {
            InitializeComponent();
        }

        private void BTN_Nuevo_Cliente_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
           FRM_NuevoCliente paginaNC = new FRM_NuevoCliente();
            paginaNC.ShowDialog();
            this.Close();
        }

        private void btn_regresar_AC_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_MENU_PRINCIPAL paginaanteriorP = new FRM_MENU_PRINCIPAL();
            paginaanteriorP.ShowDialog();
            this.Close();
        }

        private void btn_Administracion_Clientes_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_Administracion_Clientes paginaNC = new FRM_Administracion_Clientes();
            paginaNC.ShowDialog();
            this.Close();
        }
    }
}
