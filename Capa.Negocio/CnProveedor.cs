using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Entidades;
using Capa.Datos;

namespace Capa.Negocio
{
    public class CnProveedor
    {
        private CdEmpleado objEmpleado;
        private CdProveedor objProveedor;

        public CnProveedor()
        {
            objEmpleado = new CdEmpleado();
            objProveedor = new CdProveedor();
        }

        public async Task<List<Provedor>> GetProveedores()
        {
            return await objProveedor.GetProveedores();
        }

        public async Task<int> AgregarProveedor(Provedor provedor)
        {
            if (provedor.Nombre != null && provedor.Tipo != null)
                return await objProveedor.AgregarProveedor(provedor);

            return 0;
        }

        public async Task<bool> EditarProveedor(Provedor provedor)
        {
            var ProveedorComprobar = await objProveedor.GetProveedor(provedor.Idprovedor);

            if (ProveedorComprobar != null)
            {
                if (provedor.Nombre != null && provedor.Tipo != null)
                    return await objProveedor.EditarProveedor(provedor);
            }

            return false;
        }

        public async Task<bool> EliminarProveedor(int Id)
        {
            var ProveedorComprobar = await objProveedor.GetProveedor(Id);

            if (ProveedorComprobar != null)
            {
                return await objProveedor.EliminarProveedor(Id);
            }

            return false;
        }
    }
}
