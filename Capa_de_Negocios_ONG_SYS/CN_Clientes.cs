using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Datos_ONG_SYS;
using System.Data.SqlClient;
using System.Data;


namespace Capa_de_Negocios_ONG_SYS
{
   public class CN_Clientes
    {
        private CD_Clientes objetoCD = new CD_Clientes();

        public DataTable MostrarTipoProducto()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public int InsertarCliente(int tipoCliente, string nombre, string apellido, string cedula, string telefono, string direccion, string correo)
        {
            return objetoCD.InsertarCliente(tipoCliente, nombre, apellido, cedula, telefono, direccion, correo);
        }
        public void EditarCliente(int idCliente, int tipoCliente, string nombre, string apellido, string cedula, string telefono, string direccion, string correo)
        {
            objetoCD.Editar(idCliente, tipoCliente, nombre, apellido, cedula, telefono, direccion, correo);
        }

        public void EliminarCliente(int idCliente)
        {
            try
            {
                objetoCD.Eliminar(Convert.ToInt32(idCliente));
            }
            catch (Exception ex)
            {
                throw new Exception();
             }

        }
        public DataTable BuscarC(string nombreC)
        {
            DataTable dtb = new DataTable();
            dtb = objetoCD.buscarC(nombreC);
            return dtb;
        }

        public DataTable BuscarPorCedula(string cedula)
        {
            DataTable dtb = new DataTable();
            dtb = objetoCD.BuscarPorCedula(cedula);
            return dtb;
        }
    }
}
