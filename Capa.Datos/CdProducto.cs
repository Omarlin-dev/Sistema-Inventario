using Capa.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos
{
    public class CdProducto
    {
        public async Task<List<Producto>> GetProductos()
        {
            using (InventarioContext contexto = new InventarioContext())
            {
                return await contexto.Productos.Include(d => d.ProvedorNavigation).ToListAsync();
            }
        }

        public async Task<Producto> GetProducto(int Id)
        {
            using (InventarioContext contexto = new InventarioContext())
            {
                return await contexto.Productos.FirstOrDefaultAsync(d => d.Idproducto == Id);
            }
        }

        public async Task<int> AgregarProducto(Producto producto)
        {
            int IdAutogenerado = 0;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {
                    contexto.Productos.Add(producto);
                    await contexto.SaveChangesAsync();

                    IdAutogenerado = producto.Idproducto;
                }
            }
            catch
            {
                IdAutogenerado = 0;
            }


            return IdAutogenerado;
        }


        public async Task<bool> EditarProducto(Producto producto)
        {
            bool operacionExitosa = false;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {

                    contexto.Entry(producto).State = EntityState.Modified;
                    await contexto.SaveChangesAsync();
                }

                operacionExitosa = true;
            }
            catch (Exception ex)
            {
                operacionExitosa = false;
                throw new Exception(ex.Message);
            }

            return operacionExitosa;
        }


        public async Task<bool> EliminarProducto(int Id)
        {
            bool operacionExitosa = false;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {
                    var producto = await GetProducto(Id);

                    contexto.Remove(producto);
                    await contexto.SaveChangesAsync();

                    operacionExitosa = true;
                }
            }
            catch
            {
                operacionExitosa = false;
            }

            return operacionExitosa;
        }
    }
}
