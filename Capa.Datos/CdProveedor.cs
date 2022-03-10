using Capa.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Datos
{
    public class CdProveedor
    {
        public async Task<List<Provedor>> GetProveedores()
        {
            using (InventarioContext contexto = new InventarioContext())
            {
                return await contexto.Provedors.ToListAsync();
            }
        }
         
        public Provedor GetProveedor(int Id)
        {
            using (InventarioContext contexto = new InventarioContext())
            {
                return contexto.Provedors.FirstOrDefault(d => d.Idprovedor == Id);
            }
        }

        public int AgregarProveedor(Provedor provedor, out string mensaje)
        {
            int IdAutogenerado = 0;

            mensaje = string.Empty;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {
                    if(!(contexto.Provedors.Where(d => d.Tipo == provedor.Tipo).Any() || contexto.Provedors.Where(d => d.Nombre == provedor.Nombre).Any()))
                    {
                        contexto.Provedors.Add(provedor);
                        contexto.SaveChanges();

                        IdAutogenerado = provedor.Idprovedor;
                    }
                    else
                    {
                        mensaje = "Este proveedor ya existe";
                    }
                }
            }
            catch
            {
                IdAutogenerado = 0;
            }


            return IdAutogenerado;
        }


        public bool EditarProveedor(Provedor provedor, out string mensaje)
        {
            bool operacionExitosa = false;
            mensaje = string.Empty;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {
                    if (!(contexto.Provedors.Where(d => d.Tipo == provedor.Tipo).Any() || contexto.Provedors.Where(d => d.Nombre == provedor.Nombre).Any()))
                    {
                        contexto.Entry(provedor).State = EntityState.Modified;
                        contexto.SaveChanges();
                    }
                    else
                    {
                        mensaje = "Este proveedor ya existe";
                    }
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


        public bool EliminarProveedor(int Id, out string mensaje)
        {
            bool operacionExitosa = false;
            mensaje = string.Empty;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {
                    if(!contexto.Productos.Where(d => d.Provedor == Id).Any())
                    {
                        var provedor = contexto.Provedors.Find(Id);

                        contexto.Remove(provedor);
                        contexto.SaveChangesAsync();

                        operacionExitosa = true;
                    }
                    else
                    {
                        mensaje = "Este proveedor esta relacionado a un producto";
                    }
                    
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
