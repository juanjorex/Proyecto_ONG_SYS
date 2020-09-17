using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Datos_ONG_SYS;
using System.Data;
namespace Capa_de_Negocios_ONG_SYS
{
    public class UsuarioN
    {
        private UsuarioD objetoCD = new UsuarioD();


        public DataTable validarUsuario(string nombreUsuario, string contraU)
        {
            DataTable nt = new DataTable();

            nt = objetoCD.validarUsuario(nombreUsuario, contraU);
            return nt;



        }
    }
}
