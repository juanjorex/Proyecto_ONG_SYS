using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios_ONG_SYS
{
    public class Proveedor
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public int Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Proveedor() { }

        public Proveedor(int pid, string NombreP, string rucp, int provinciap, string ciudadp, string direccionp, string Telefonop)
        {
            this.Identificacion = pid;
            this.Nombre = NombreP;
            this.Ruc = rucp;
            this.Provincia = provinciap;
            this.Ciudad = ciudadp;
            this.Direccion = direccionp;
            this.Telefono = Telefonop;

        }
    }
}
