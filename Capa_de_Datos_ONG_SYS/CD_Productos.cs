using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_Datos_ONG_SYS
{
    public class CD_Productos
    {
        private Conexion_DB con = new Conexion_DB();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leerfilas;

        public DataTable ListarTipoProductos()
        {
            comando = new SqlCommand();
            DataTable TablaP = new DataTable();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "MostrarTipoProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leerfilas = comando.ExecuteReader();
            TablaP.Load(leerfilas);
            leerfilas.Close();
            con.CerrarConexion();
            return TablaP;
        }

        public DataTable ListarProductos()
        {
            comando = new SqlCommand();
            DataTable TablaPro = new DataTable();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "Mostrar_Productos";
            comando.CommandType = CommandType.StoredProcedure;
            leerfilas = comando.ExecuteReader();
            TablaPro.Load(leerfilas);
            leerfilas.Close();
            con.CerrarConexion();
            return TablaPro;
        }

        public DataTable BuscarProductos(string nombreProducto)
        {
            comando = new SqlCommand();
            DataTable TablaPro = new DataTable();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "Mostrar_Productos";
            comando.CommandText = "select * from vProductos WHERE NombreProducto like('%" + nombreProducto + "%') ";
            comando.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter sqd = new SqlDataAdapter(comando);
            sqd.Fill(dta);
            con.CerrarConexion();
            return dta;
        }

        public void Insertar(string NombreProducto, int idTipoProducto, int idProveedor, string marca, decimal precio, int stock)
        {
            comando = new SqlCommand();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "IngresarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NombreProducto", NombreProducto);
            comando.Parameters.AddWithValue("@idTipoProducto", idTipoProducto);
            comando.Parameters.AddWithValue("@idProveedor", idProveedor);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Stock", stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();

        }

        public void Actualizar(string NombreProducto, int idTipoProducto, int idProveedor, string marca, decimal precio, int stock,int id)
        {
            comando = new SqlCommand();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@NombreProducto", NombreProducto);
            comando.Parameters.AddWithValue("@idTipoProducto", idTipoProducto);
            comando.Parameters.AddWithValue("@idProveedor", idProveedor);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Stock", stock);
            comando.Parameters.AddWithValue("@idProductoaActualizar", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();

        }

        public void EliminarProducto(int idProducto)
        {
            comando = new SqlCommand();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            con.CerrarConexion();
        }

        public object ObtenerProveedor(int idProducto)
        {
            comando = new SqlCommand();
            DataTable TablaPro = new DataTable();
            comando.Connection = con.AbrirConexion();
            comando.CommandText = "Obtener_Proveedor_del_Producto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProducto", idProducto);
            leerfilas = comando.ExecuteReader();
            TablaPro.Load(leerfilas);
            leerfilas.Close();
            comando.Parameters.Clear();
            con.CerrarConexion();
            return TablaPro.Rows[0].ItemArray[0];
        }



    }
}
