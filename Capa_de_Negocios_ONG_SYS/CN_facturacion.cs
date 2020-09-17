using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Datos_ONG_SYS;
using System.Data;

namespace Capa_de_Negocios_ONG_SYS
{
    public class CN_facturacion
    {

        CD_Facturacion objFc = new CD_Facturacion();

        public DataTable MostrarDetalle()
        {
            //CD_Facturacion objF = new CD_Facturacion();
            DataTable tabla = new DataTable();
            tabla = objFc.MostrarDetalle();
            return tabla;
        }
        public DataTable MostrarSIT(int idF)
        {
            DataTable tabla1 = new DataTable();
            tabla1 = objFc.MostrarSIT(Convert.ToInt32(idF));
            return tabla1;
        }

        public int CrearFactura(string idCliente, string  idUsuario)
        {
            return objFc.Crearfactura(Convert.ToInt32(idCliente), Convert.ToInt32(idUsuario));
        }

        public DataTable ObtenerDatosDeLaFactura(string idFactura)
        {
            return objFc.ObtenerCabecera(idFactura);
        }

        public DataTable ObtenerDetalleDeLaFactura(string idFactura)
        {
            return objFc.ObtenerDetalle(idFactura);
        }

        public void AgregarProducto(string idProducto, string idFactura, string cantidad)
        {
            try
            {
                objFc.AgregarProducto(Convert.ToInt32(idProducto), Convert.ToInt32(idFactura), Convert.ToInt32(cantidad));
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void AgregarServicio(string idServicio, string idFactura, string cantidad)
        {
            objFc.AgregarServicio(Convert.ToInt32(idServicio), Convert.ToInt32(idFactura), Convert.ToInt32(cantidad));
        }

        public DataTable MostrarFacturas()
        {
            return objFc.ListarFacturas();
        }
        public DataTable BuscarFactura(string nombreS)
        {
            DataTable dtb = new DataTable();
            dtb = objFc.buscarF(nombreS);
            return dtb;



        }
    }
}
