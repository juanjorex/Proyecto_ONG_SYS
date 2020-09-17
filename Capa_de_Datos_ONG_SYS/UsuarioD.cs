using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Capa_de_Datos_ONG_SYS
{
    public class UsuarioD
    {
        private Conexion_DB conexion = new Conexion_DB();

        int variable;
        SqlCommand comandos = new SqlCommand();
        public DataTable validarUsuario(string usuario, string contra)
        {
            SqlCommand comandos = new SqlCommand();

            comandos.Connection = conexion.AbrirConexion();
            comandos.CommandText = "verificarUsuario";
            comandos.CommandType = CommandType.StoredProcedure;
            comandos.Parameters.AddWithValue("@nombreUsuario", usuario);
            comandos.Parameters.AddWithValue("@contraseniaUsuario", contra);
            SqlDataAdapter ad = new SqlDataAdapter(comandos);
            DataTable dta = new DataTable();
            ad.Fill(dta);
            conexion.CerrarConexion();
            return dta;



        }
        //public DataTable Validar(string usuario, string contra)
        //{
        //    comandos.Connection = conexion.AbrirConexion();
        //    SqlCommand cmd = new SqlCommand("select*from tblUsuario where nombreUsuario=@nombreUsuario and contraseniaUsuario =@contraseniaUsuario", conexion);
        //    cmd.Parameters.AddWithValue("nombreUsuario", usuario);
        //    cmd.Parameters.AddWithValue("@contraseniaUsuario", contra);
        //    SqlDataAdapter ad = new SqlDataAdapter(comandos);
        //    DataTable dta = new DataTable();
        //    ad.Fill(dta);
        //    conexion.CerrarConexion();
        //    return dta;

        //}
    }
}
