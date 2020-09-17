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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ONG_SYS
{
    /// <summary>
    /// Interaction logic for FRM_Buscar_Producto.xaml
    /// </summary>
    public partial class FRM_Buscar_Producto : Window
    {
        public string idProducto = null;
        public string nombreProducto = null;
        CN_Productos objetoCN = new CN_Productos();
        private Facturacion padre;

        public FRM_Buscar_Producto(Facturacion parametro)
        {
            InitializeComponent();
            padre = parametro;

        }
        public FRM_Buscar_Producto()
        {
            InitializeComponent();
        }

        private void MostrarProductos(string nombreProducto)
        {
            dgv_productos.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = objetoCN.buscarProductos(nombreProducto) });
        }

        private void dgv_productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dgv_productos.SelectedItem as DataRowView;
            if (rowView != null)
            {
                nombreProducto = rowView[1].ToString();
                idProducto = rowView[0].ToString();
                padre.txt_producto.Text = nombreProducto;
                padre.esProducto = true;
                padre.Show();
                this.Close();
            }
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            MostrarProductos(txt_nombreProducto.Text);
        }
    }
}
