using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_de_Datos_ONG_SYS
{
    public class CD_Proveedor
    {
            private Conexion_DB con = new Conexion_DB();
            private SqlCommand comando = new SqlCommand();
            private SqlDataReader leerfilas;



            public DataTable ListarProvincias()
            {
                comando = new SqlCommand();
                DataTable TablaP = new DataTable();
                comando.Connection = con.AbrirConexion();
                comando.CommandText = "MostrarProvincias";
                comando.CommandType = CommandType.StoredProcedure;
                leerfilas = comando.ExecuteReader();
                TablaP.Load(leerfilas);
                leerfilas.Close();
                con.CerrarConexion();
                return TablaP;
            }

            public DataTable ListarProveedores()
            {
                comando = new SqlCommand();
                DataTable TablaPro = new DataTable();
                comando.Connection = con.AbrirConexion();
                comando.CommandText = "Mostrar_Proveedores3";
                comando.CommandType = CommandType.StoredProcedure;
                leerfilas = comando.ExecuteReader();
                TablaPro.Load(leerfilas);
                leerfilas.Close();
                con.CerrarConexion();
                return TablaPro;
            }

            public DataTable Buscar(string nombreProveedor)
            {
                comando = new SqlCommand();
                DataTable TablaPro = new DataTable();
                comando.Connection = con.AbrirConexion();
                comando.CommandText = "SELECT * FROM VProveedores WHERE Nombre LIKE ('%" + nombreProveedor + "%')";
                leerfilas = comando.ExecuteReader();
                TablaPro.Load(leerfilas);
                leerfilas.Close();
                con.CerrarConexion();
                return TablaPro;
            }


            public void Insertar(string NombreProveedor, string rucProveedor, int idProvincia, string ciudad, string direccion, string telefono)
            {
                comando = new SqlCommand();
                comando.Connection = con.AbrirConexion();
                comando.CommandText = "AgregarProveedor";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                comando.Parameters.AddWithValue("@rucProveedor", rucProveedor);
                comando.Parameters.AddWithValue("@idProvincia", idProvincia);
                comando.Parameters.AddWithValue("@ciudad", ciudad);
                comando.Parameters.AddWithValue("@direccionProveedor", direccion);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                con.CerrarConexion();

            }

            public void Editar(string NombreProveedor, string rucProveedor, int idProvincia, string ciudad, string direccion, string telefono, int id)
            {
                comando = new SqlCommand();
                comando.Connection = con.AbrirConexion();
                comando.CommandText = "ActualizarProveedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NombreProveedor", NombreProveedor);
                comando.Parameters.AddWithValue("@rucProveedor", rucProveedor);
                comando.Parameters.AddWithValue("@idProvincia", idProvincia);
                comando.Parameters.AddWithValue("@ciudad", ciudad);
                comando.Parameters.AddWithValue("@direccionProveedor", direccion);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@idProveedorActualizar", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                con.CerrarConexion();
            }

            public void EliminarProveedor(int idProveedor)
            {
                comando = new SqlCommand();
                comando.Connection = con.AbrirConexion();
                comando.CommandText = "EliminarProveedor";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idProveedor", idProveedor);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                con.CerrarConexion();
            }
        }
    }


