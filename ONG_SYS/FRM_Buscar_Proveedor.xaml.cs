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
    /// Lógica de interacción para FRM_Buscar_Proveedor.xaml
    /// </summary>
    public partial class FRM_Buscar_Proveedor : Window
    {
        public string idProveedor = null;
        public string nombreProveedor = null;
        CN_Proveedores objetoCN = new CN_Proveedores();
        private FRM_Administracion_Productos padre;

        public FRM_Buscar_Proveedor(FRM_Administracion_Productos parametro)
        {
            InitializeComponent();
            padre = parametro;

        }

        public FRM_Buscar_Proveedor()
        {
            InitializeComponent();
        }

        private void MostrarProveedores()
        {
            CN_Proveedores objec = new CN_Proveedores();
            dgvResultado.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objec.mostrarProveedores() });

        }

        private void dgvResultado_Loaded(object sender, RoutedEventArgs e)
        {
            MostrarProveedores();
        }

        private void dgvResultado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dgvResultado.SelectedItem as DataRowView;
            if (dgvResultado.SelectedItem != null)
            {
            }
            if (rowView != null)
            {
                padre.TXT_Nombre_Proveedor.Text = rowView[1].ToString();
                idProveedor = rowView[0].ToString();
        
                padre.Show();
                this.Close();

            }
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
