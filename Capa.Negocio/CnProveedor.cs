using Capa.Datos;
using Capa.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public int AgregarProveedor(Provedor provedor, out string mensaje)
        {
            mensaje = string.Empty;
            if (provedor.Nombre != null && provedor.Tipo != null)
                return objProveedor.AgregarProveedor(provedor, out mensaje);

            return 0;
        }

        public bool EditarProveedor(Provedor provedor, out string mensaje)
        {
            var ProveedorComprobar = objProveedor.GetProveedor(provedor.Idprovedor);
            mensaje = string.Empty;

            if (ProveedorComprobar != null)
            {
                if (provedor.Nombre != null && provedor.Tipo != null)
                    return objProveedor.EditarProveedor(provedor, out mensaje);
            }

            return false;
        }

        public bool EliminarProveedor(int Id, out string mensaje)
        {
            var ProveedorComprobar = objProveedor.GetProveedor(Id);
            mensaje = string.Empty;

            if (ProveedorComprobar != null)
            {
                return objProveedor.EliminarProveedor(Id, out mensaje);
            }
            else
            {
                mensaje = "Este proveedor no existe";
            }

            return false;
        }
    }
}
