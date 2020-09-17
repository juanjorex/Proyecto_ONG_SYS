using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_Datos_ONG_SYS
{
    public class CD_Clientes
    {
        private Conexion_DB conexion = new Conexion_DB();
        SqlDataReader leerDatos;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable buscarC(string nombre)
        {
            comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.Text;
            //Comandos.CommandText = "select idServicio, nombreTiposervicio, nombreServicio,valorServicio from tblServicio join tblTipoServicio on tblServicio.idTiposervicio = tblTipoServicio.idTiposervicio like('" + nombre + "%')";
            comando.CommandText = "select*from vClientes WHERE Cliente like('%" + nombre + "%') ";
            comando.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(comando);
            sqd.Fill(dta);
            conexion.CerrarConexion();
            return dta;

        }

        public DataTable BuscarPorCedula(string cedula)
        {
            comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.Text;
            //Comandos.CommandText = "select idServicio, nombreTiposervicio, nombreServicio,valorServicio from tblServicio join tblTipoServicio on tblServicio.idTiposervicio = tblTipoServicio.idTiposervicio like('" + nombre + "%')";
            comando.CommandText = "SELECT * FROM vClientes WHERE Cedula LIKE " + cedula;
            comando.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(comando);
            sqd.Fill(dta);
            conexion.CerrarConexion();
            return dta;

        }

        public DataTable Mostrar()
        {
            comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_VerClientes";
            comando.CommandType = CommandType.StoredProcedure;
            leerDatos = comando.ExecuteReader();
            tabla.Load(leerDatos);
            conexion.CerrarConexion();
            return tabla;
        }


        public int InsertarCliente(int tipoCliente, string nombre, string apellido, string cedula, string telefono, string direccion, string correo)
        {
            comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_IngresoCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@TipoClienteID", tipoCliente);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@correo", correo);
            SqlParameter outputIdParam = new SqlParameter("@id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            comando.Parameters.Add(outputIdParam);
            comando.ExecuteNonQuery();
            int id = int.Parse(outputIdParam.Value.ToString());
            comando.Parameters.Clear();
            return id;
        }
        public void Editar( int idCliente, int tipoCliente, string nombre, string apellido, string cedula, string telefono, string direccion, string correo)
        {
            comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_ActualizarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@clienteID", idCliente );
            comando.Parameters.AddWithValue("@TipoClienteID", tipoCliente);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int idCliente)
        {
            comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "sp_EliminarCliente";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@clienteID", idCliente);
            try
            {
                comando.ExecuteNonQuery();
            }catch (SqlException ex)
            {
                comando.Parameters.Clear();
                throw new Exception();
            }
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
