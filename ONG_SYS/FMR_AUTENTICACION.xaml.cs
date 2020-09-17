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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_de_Negocios_ONG_SYS;
using System.Data;

namespace ONG_SYS
{
    /// <summary>
    /// Lógica de interacción para FMR_AUTENTICACION.xaml
    /// </summary>
    public partial class FMR_AUTENTICACION : Window
    {
        private static FMR_AUTENTICACION instancia = null;
        public FMR_AUTENTICACION()
        {
            InitializeComponent();
            instancia = this;
        }

        public static FMR_AUTENTICACION GetInstancia()
        {
            if(instancia == null)
            {
                instancia = new FMR_AUTENTICACION();
            }
            return instancia;
        }
        UsuarioN objetoU = new UsuarioN();
       public string   valorid= null ;
        private bool usuario = false;

        public void logU()
        {
            DataTable Fr = new DataTable();

            Fr = objetoU.validarUsuario(this.txtUsuario.Text, this.txtcontraU.Password);
            try
            {
                if (Fr.Rows.Count == 1)
                {
                    string dtU = Fr.Rows[0][0].ToString();

                    valorid = dtU;

                    this.Hide();
                    FRM_MENU_PRINCIPAL menu = new FRM_MENU_PRINCIPAL();

                    menu.ShowDialog();
                    this.Close();


                }
                else   
                {
                    MessageBox.Show("Usuario o contraseña incorrecta!");
                    Fr.Clear();
                    Fr.Clear();
                    txtUsuario.Clear();
                    txtcontraU.Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en :" + ex);
            }

        }


        private void btnIn_Click(object sender, RoutedEventArgs e)
        {



            
            logU();

            

        }

        private void btnSa_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir del Sistema?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btncn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir del Sistema?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
