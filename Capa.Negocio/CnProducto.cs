using Capa.Datos;
using Capa.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Negocio
{
    public class CnProducto
    {
        private CdProducto objProducto;

        public CnProducto()
        {
            objProducto = new CdProducto();
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await objProducto.GetProductos();
        }

        public async Task<int> AgregarProducto(Producto producto)
        {
            if (producto.Nombre != null && producto.Precio != null && producto.Provedor != 0 && producto.Cantidad != 0)
                return await objProducto.AgregarProducto(producto);

            return 0;
        }

        public async Task<bool> EditarProducto(Producto producto)
        {
            var productoComprobar = await objProducto.GetProducto(producto.Idproducto);

            if (productoComprobar != null)
            {
                if (producto.Nombre != null && producto.Precio != null && producto.Provedor != 0 && producto.Cantidad != 0)
                    return await objProducto.EditarProducto(producto);
            }

            return false;
        }

        public async Task<bool> EliminarProducto(int Id)
        {
            var productoComprobar = objProducto.GetProducto(Id);

            if (productoComprobar != null)
            {
                return await objProducto.EliminarProducto(Id);
            }

            return false;
        }
    }
}
