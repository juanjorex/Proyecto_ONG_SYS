using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_Datos_ONG_SYS
{
    public class CD_Clientefactura
    {
        private Conexion_DB conexion = new Conexion_DB();
        SqlDataReader leer;

        DataTable tabla = new DataTable();
        DataTable tabla2 = new DataTable();
        SqlCommand Comandos = new SqlCommand();
        public DataTable MostrarClientesF()
        {
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandText = "MostrarCliente";
            Comandos.CommandType = CommandType.StoredProcedure;
            leer = Comandos.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public DataTable buscarC(string nombre)
        {
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandType = CommandType.Text;
            //Comandos.CommandText = "select idServicio, nombreTiposervicio, nombreServicio,valorServicio from tblServicio join tblTipoServicio on tblServicio.idTiposervicio = tblTipoServicio.idTiposervicio like('" + nombre + "%')";
            Comandos.CommandText = "select*from vClientes WHERE Cliente like('%" + nombre + "%') ";
            Comandos.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(Comandos);
            sqd.Fill(dta);
            conexion.CerrarConexion();
            return dta;

        }
    }
}
