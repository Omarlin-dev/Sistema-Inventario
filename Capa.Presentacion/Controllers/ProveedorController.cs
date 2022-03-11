using Capa.Negocio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using Capa.Entidades;
using Capa.Entidades.ViewModel;
using Newtonsoft.Json;

namespace Capa.Presentacion.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IMapper mapper;
        private CnProveedor cnProveedor = new CnProveedor();

        public ProveedorController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult ProveedorIndex()
        {
            return View();
        }

        public async Task<JsonResult> ObtenerProveedores()
        {
            var TodosProveedorDatos = await cnProveedor.GetProveedores();

            var todosProveedorMostrar = mapper.Map<List<ProveedorViewModel>>(TodosProveedorDatos);

            return Json(new { data = todosProveedorMostrar }, new JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult GuadarProveedor([FromBody] ProveedorViewModel provedorModel)
        {
            object resultado = false;
            string mensaje = string.Empty;

            var proveedor = mapper.Map<Provedor>(provedorModel);

            if (!ModelState.IsValid)
            {
                return Json(new { resultado = resultado }, new JsonSerializerSettings());
            }

            if (proveedor != null)
            {
                if (proveedor.Idprovedor == 0)
                {
                    resultado = cnProveedor.AgregarProveedor(proveedor, out mensaje);
                }
                else
                {
                    resultado = cnProveedor.EditarProveedor(proveedor, out mensaje);
                }
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, new JsonSerializerSettings());
        }

        [HttpGet]
        public JsonResult EliminarProveedor(int Id)
        {
            string mensaje = string.Empty;

            bool resultado = cnProveedor.EliminarProveedor(Id, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, new JsonSerializerSettings());
        }
    }
}
