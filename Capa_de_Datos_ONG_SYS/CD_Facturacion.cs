using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Capa_de_Datos_ONG_SYS
{
    public class CD_Facturacion
    {

        private Conexion_DB conexion = new Conexion_DB();
        SqlDataReader leer;

        DataTable tabla = new DataTable();
        DataTable tabla2 = new DataTable();
        SqlCommand Comandos = new SqlCommand();
        public DataTable MostrarDetalle()
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandText = "Mostrardetalle";
            Comandos.CommandType = CommandType.StoredProcedure;
            leer = Comandos.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public DataTable MostrarSIT(int idF)
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandText = "MostrarSIT";
            Comandos.CommandType = CommandType.StoredProcedure;
            Comandos.Parameters.AddWithValue("@id", idF);
            leer = Comandos.ExecuteReader();
            tabla2.Load(leer);
            Comandos.Parameters.Clear();
            conexion.CerrarConexion();
            return tabla2;
        }
        public int Crearfactura(int idCliente, int idUsuario)
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandText = "sp_NuevaFactura";
            Comandos.CommandType = CommandType.StoredProcedure;
            Comandos.Parameters.AddWithValue("@clienteID ", idCliente);
            Comandos.Parameters.AddWithValue("@usuarioID", idUsuario);
            Comandos.Parameters.Add("@id", SqlDbType.Int);
            Comandos.Parameters["@id"].Direction = ParameterDirection.Output;
            Comandos.ExecuteNonQuery();
            conexion.CerrarConexion();
            int id = int.Parse(Comandos.Parameters["@id"].Value.ToString());
            Comandos.Parameters.Clear();
            return id;
        }

        public DataTable ObtenerCabecera(string idFactura)
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandType = CommandType.Text;
            Comandos.CommandText = "select * from vEncabezado where ID = " + idFactura;
            Comandos.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(Comandos);
            sqd.Fill(dta);
            conexion.CerrarConexion();
            return dta;
        }

        public DataTable ObtenerDetalle(string idFactura)
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandType = CommandType.Text;
            Comandos.CommandText = "select * from vDetalle where iD = " + idFactura;
            Comandos.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(Comandos);
            sqd.Fill(dta);
            conexion.CerrarConexion();
            return dta;
        }

        public void AgregarProducto(int idProducto, int idFactura, int cantidad)
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandText = "sp_IngresoProducto";
            Comandos.CommandType = CommandType.StoredProcedure;
            Comandos.Parameters.AddWithValue("@productoID", idProducto);
            Comandos.Parameters.AddWithValue("@facturaID", idFactura);
            Comandos.Parameters.AddWithValue("@cantidad", cantidad);
            try
            {
                Comandos.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Comandos.Parameters.Clear();
                throw new Exception();
            }
            Comandos.Parameters.Clear();
        }

        public void AgregarServicio(int idServicio, int idFactura, int cantidad)
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandText = "sp_IngresoServicio";
            Comandos.CommandType = CommandType.StoredProcedure;
            Comandos.Parameters.AddWithValue("@servicioID", idServicio);
            Comandos.Parameters.AddWithValue("@facturaID", idFactura);
            Comandos.Parameters.AddWithValue("@cantidad", cantidad);
            Comandos.ExecuteNonQuery();
            Comandos.Parameters.Clear();
        }

        public DataTable ListarFacturas()
        {
            Comandos = new SqlCommand();
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandType = CommandType.Text;
            Comandos.CommandText = "select * from vEncabezado";
            Comandos.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(Comandos);
            sqd.Fill(dta);
            conexion.CerrarConexion();
            return dta;
        }
        public DataTable buscarF(string nombre)
        {
            Comandos.Connection = conexion.AbrirConexion();
            Comandos.CommandType = CommandType.Text;
            //Comandos.CommandText = "select idServicio, nombreTiposervicio, nombreServicio,valorServicio from tblServicio join tblTipoServicio on tblServicio.idTiposervicio = tblTipoServicio.idTiposervicio like('" + nombre + "%')";
            Comandos.CommandText = "select * from vEncabezado where [Nombre Cliente] like('%" + nombre + "%')   ";
            Comandos.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(Comandos);
            sqd.Fill(dta);
            conexion.CerrarConexion();
            return dta;


        }
    }
}
