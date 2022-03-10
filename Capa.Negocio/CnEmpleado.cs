using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Entidades;
using Capa.Datos;

namespace Capa.Negocio
{
    public class CnEmpleado
    {
        private CdEmpleado objEmpleado;

        public CnEmpleado()
        {
            objEmpleado = new CdEmpleado();
        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            return await objEmpleado.GetEmpleados();
        }

        public async Task<int> AgregarEmpleado(Empleado empleado)
        {
            if(empleado.Nombre != null && empleado.Apellido != null && empleado.Sexo != null)
                return await objEmpleado.AgregarEmpleado(empleado);

            return 0;
        }

        public async Task<bool> EditarEmpleado(Empleado empleado)
        {
            var empleadoComprobar = await objEmpleado.GetEmpleado(empleado.Idempleado);

            if (empleadoComprobar != null)
            {
                if (empleado.Nombre != null && empleado.Apellido != null && empleado.Sexo != null)
                    return await objEmpleado.EditarEmpleado(empleado);
            }

            return false;
        }

        public async Task<bool> EliminarEmpleado(int Id)
        {
            var empleadoComprobar = await objEmpleado.GetEmpleado(Id);

            if (empleadoComprobar != null)
            {
                return await objEmpleado.EliminarEmpleado(Id);
            }

            return false;
        }
    }
}
