using Capa.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capa.Datos
{
    public class CdEmpleado
    {   
        public async Task<List<Empleado>> GetEmpleados()
        {
            using (InventarioContext contexto = new InventarioContext())
            {
                return await contexto.Empleados.ToListAsync();
            }
        } 

        public async Task<Empleado> GetEmpleado(int Id)
        {
            using (InventarioContext contexto = new InventarioContext())
            {
                return await contexto.Empleados.FirstOrDefaultAsync(d => d.Idempleado == Id);
            }
        }

        public async Task<int> AgregarEmpleado(Empleado empleado)
        {
            int IdAutogenerado = 0;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {
                    contexto.Empleados.Add(empleado);
                    await contexto.SaveChangesAsync();

                    IdAutogenerado = empleado.Idempleado;
                }
            }
            catch 
            {
                IdAutogenerado = 0;
            }


            return IdAutogenerado;
        }
        

        public async Task<bool> EditarEmpleado(Empleado empleado)
        {
            bool operacionExitosa = false;

            try
            {
                using(InventarioContext contexto = new InventarioContext())
                {

                    contexto.Entry(empleado).State = EntityState.Modified;
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
        

        public async Task<bool> EliminarEmpleado(int Id)
        {
            bool operacionExitosa = false;

            try
            {
                using (InventarioContext contexto = new InventarioContext())
                {
                    var empleado = await contexto.Empleados.FindAsync(Id);

                    contexto.Remove(empleado);
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
