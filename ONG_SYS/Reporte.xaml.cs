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
    /// Interaction logic for Reporte.xaml
    /// </summary>
    public partial class Reporte : Window
    {
        public Reporte()
        {
            InitializeComponent();
        }


        private void mostrarFactura()
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new
                Microsoft.Reporting.WinForms.ReportDataSource();
                dbONG_VCompleta2DataSet dataset = new dbONG_VCompleta2DataSet();

                dataset.BeginInit();

                reportDataSource1.Name = "FacturaDataSet";
                //Name of the report dataset in our .RDLC file

                reportDataSource1.Value = dataset.Factura;
                this.reportViewer.LocalReport.DataSources.Clear();
                this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer.LocalReport.ReportPath = "..\\..\\FacturaReport.rdlc";
                dataset.EndInit();

                //fill data into WpfApplication4DataSet
                dbONG_VCompleta2DataSetTableAdapters.FacturaTableAdapter
                accountsTableAdapter = new
                dbONG_VCompleta2DataSetTableAdapters.FacturaTableAdapter();

                accountsTableAdapter.ClearBeforeFill = true;
                accountsTableAdapter.FillBy(dataset.Factura, Convert.ToInt32(txt_idFactura.Text));
                reportViewer.LocalReport.Refresh();
                reportViewer.RefreshReport();
            }catch(Exception ex)
            {
                MessageBox.Show("Ingrese un identificador válido (Numérico)");
            }
        }

        private void btn_Agregar_NC_Click(object sender, RoutedEventArgs e)
        {
            mostrarFactura();
        }

        private void btn_Regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FRM_MENU_PRINCIPAL paginaanteriorP = new FRM_MENU_PRINCIPAL();
            paginaanteriorP.ShowDialog();
            this.Close();
        }
    }
}
