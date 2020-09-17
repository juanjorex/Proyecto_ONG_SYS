using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Datos_ONG_SYS;
using System.Collections.ObjectModel;
using System.Data;

namespace Capa_de_Negocios_ONG_SYS
{
    public class CN_Proveedores
    {
        private CD_Proveedor proveedor_cd = new CD_Proveedor();


        public DataTable mostrarProvincias()
        {
            DataTable tablaProvincias = new DataTable();
            tablaProvincias = proveedor_cd.ListarProvincias();
            return tablaProvincias;
        }

        public DataTable mostrarProveedores()
        {
            DataTable tablaProveedores = new DataTable();
            tablaProveedores = proveedor_cd.ListarProveedores();
            return tablaProveedores;
        }

        public DataTable Buscar(string nombreProveedor)
        {
            return proveedor_cd.Buscar(nombreProveedor);
        }


        public ObservableCollection<Provincia> GetProvincias()
        {
            ObservableCollection<Provincia> provincias = new ObservableCollection<Provincia>();

            foreach (DataRow item in mostrarProvincias().Rows)
            {
                var provincia = new Provincia
                {
                    Id = int.Parse(item["idProvincia"].ToString()),
                    Nombre = item["NombreProvincia"].ToString(),
                };

                provincias.Add(provincia);
            }

            return provincias;
        }

        public void InsertarProv(string NombreProveedor, string rucProveedor, int idProvincia, string ciudad, string direccion, string telefono)
        {
            proveedor_cd.Insertar(NombreProveedor, rucProveedor, Convert.ToInt32(idProvincia), ciudad, direccion, telefono);

        }

        public void EditarProd(string NombreProveedor, string rucProveedor, int idProvincia, string ciudad, string direccion, string telefono, string id)
        {
            proveedor_cd.Editar(NombreProveedor, rucProveedor, Convert.ToInt32(idProvincia), ciudad, direccion, telefono, Convert.ToInt32(id));
        }

        public void EliminarProv(string idProveedor)
        {


            proveedor_cd.EliminarProveedor(Convert.ToInt32(idProveedor));

        }
    }
}
