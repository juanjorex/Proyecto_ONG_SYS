using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Datos_ONG_SYS;
using System.Data;

namespace Capa_de_Negocios_ONG_SYS
{
    public class CN_Clientefacturacion
    {
        private CD_Clientefactura objetoCl = new CD_Clientefactura();
        public DataTable MostrarClienteF()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCl.MostrarClientesF();
            return tabla;



        }
        public DataTable BuscarC(string nombreC)
        {
            DataTable dtb = new DataTable();
            dtb = objetoCl.buscarC(nombreC);
            return dtb;
        }
    }
}
