using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios_ONG_SYS
{
    public class Productos
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public int Tipo_de_Producto { get; set; }
        public int Proveedor { get; set; }
        public string Marca { get; set; }
        public float Valor_Unitario { get; set; }
        public int Stock { get; set; }
    }
}
