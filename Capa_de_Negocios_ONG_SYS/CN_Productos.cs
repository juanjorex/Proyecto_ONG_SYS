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
    public class CN_Productos
    {
        private CD_Productos producto_cd = new CD_Productos();

        public DataTable mostrarTipoProducto()
        {
            DataTable tablaTipoProducto = new DataTable();
            tablaTipoProducto = producto_cd.ListarTipoProductos();
            return tablaTipoProducto;
        }

        public DataTable mostrarProductos()
        {
            DataTable tablaProductos = new DataTable();
            tablaProductos = producto_cd.ListarProductos();
            return tablaProductos;
        }

        public DataTable buscarProductos(string nombreProducto)
        {
            DataTable tablaProductos = new DataTable();
            tablaProductos = producto_cd.BuscarProductos(nombreProducto);
            return tablaProductos;
        }

        public ObservableCollection<TipoProducto> GetTipoProductos()
        {
            ObservableCollection<TipoProducto> tproducto = new ObservableCollection<TipoProducto>();

            foreach (DataRow item in mostrarTipoProducto().Rows)
            {
                var tproductos = new TipoProducto
                {
                    Id = int.Parse(item["idTipoProducto"].ToString()),
                    Tipo_de_Producto = item["NombreTipoP"].ToString(),
                };

                tproducto.Add(tproductos);
            }

            return tproducto;
        }

        public void Insertar(string NombreProducto, int idTipoProducto, int idProveedor, string marca, string precio, int stock)
        {
            producto_cd.Insertar(NombreProducto, Convert.ToInt32(idTipoProducto), Convert.ToInt32(idProveedor), marca, Convert.ToDecimal(precio), Convert.ToInt32(stock));
        }
        public void Editar(string NombreProducto, int idTipoProducto, int idProveedor, string marca, string precio, int stock, int id)
        {
            producto_cd.Actualizar(NombreProducto, Convert.ToInt32(idTipoProducto), Convert.ToInt32(idProveedor), marca, Convert.ToDecimal(precio), stock, Convert.ToInt32(id));
        }
        public void Eliminar(string id)
        {
            producto_cd.EliminarProducto(Convert.ToInt32(id));
        }

        public int ObtenerProveedor(int idProducto)
        {
            return Convert.ToInt32(producto_cd.ObtenerProveedor(idProducto));
        }
    }














    /* public class CN_Productos
     {
         private CD_Productos producto_cd = new CD_Productos();

         public DataTable mostrarTipoProducto()
         {
             DataTable tablaTipoProducto = new DataTable();
             tablaTipoProducto =producto_cd.ListarTipoProductos();
             return tablaTipoProducto;
         }

         public DataTable mostrarProductos()
         {
             DataTable tablaProductos = new DataTable();
             tablaProductos = producto_cd.ListarProductos();
             return tablaProductos;
         }

         public DataTable buscarProductos(string nombreProducto)
         {
             DataTable tablaProductos = new DataTable();
             tablaProductos = producto_cd.BuscarProductos(nombreProducto);
             return tablaProductos;
         }

         public ObservableCollection<TipoProducto> GetTipoProductos()
         {
             ObservableCollection<TipoProducto> tproducto = new ObservableCollection<TipoProducto>();

             foreach (DataRow item in mostrarTipoProducto().Rows)
             {
                 var tproductos = new TipoProducto
                 {
                     Id = int.Parse(item["idTipoProducto"].ToString()),
                     Tipo_de_Producto= item["NombreTipoP"].ToString(),
                 };

                 tproducto.Add(tproductos);
             }

             return tproducto;
         }

         public void Insertar(string NombreProducto, int idTipoProducto, int idProveedor, string marca, string precio, int stock)
         {
             producto_cd.Insertar(NombreProducto, Convert.ToInt32(idTipoProducto),Convert.ToInt32(idProveedor),marca,Convert.ToDecimal(precio),Convert.ToInt32(stock));
         }
         public void Editar(string NombreProducto, int idTipoProducto, int idProveedor, string marca, string precio, int stock,int id)
         {
             producto_cd.Actualizar(NombreProducto, Convert.ToInt32(idTipoProducto), Convert.ToInt32(idProveedor), marca,Convert.ToDecimal(precio), stock,Convert.ToInt32(id));
         }
         public void Eliminar(string id)
         {
             producto_cd.EliminarProducto(Convert.ToInt32(id));
         }

         public int ObtenerProveedor(int idProducto)
         {
             return Convert.ToInt32(producto_cd.ObtenerProveedor(idProducto));
         }
     }*/
}
