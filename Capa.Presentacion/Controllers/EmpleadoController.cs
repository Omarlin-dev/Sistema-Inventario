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
    public class EmpleadoController : Controller
    {
        private readonly IMapper mapper;
        private CnEmpleado cnEmpleado = new CnEmpleado();

        public EmpleadoController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult EmpleadoIndex()
        {
            return View();
        }

        public async Task<JsonResult> ObtenerEmplados()
        {
            var TodosEmpleadosDatos = await cnEmpleado.GetEmpleados();

            var todosEmpleadoMostrar = mapper.Map<List<EmpleadoViewModel>>(TodosEmpleadosDatos);
             
            return Json(new { data = todosEmpleadoMostrar }, new JsonSerializerSettings());
        }

        [HttpPost]
        public async Task<JsonResult> GuadarEmpleado([FromBody] EmpleadoViewModel empleadoModel)
        {
            object resultado=false;

            var empleado = mapper.Map<Empleado>(empleadoModel);

            if (!ModelState.IsValid)
            {
                return Json(new { resultado = resultado }, new JsonSerializerSettings());
            }

            if(empleado != null)
            {
                if (empleado.Idempleado == 0)
                {
                    resultado = await cnEmpleado.AgregarEmpleado(empleado);
                }
                else
                {
                    resultado = await cnEmpleado.EditarEmpleado(empleado);
                }
            }

            return Json(new { resultado = resultado }, new JsonSerializerSettings());
        }

        [HttpGet]
        public async Task<JsonResult> EliminarEmpleado(int Id)
        {
            bool resultado= await cnEmpleado.EliminarEmpleado(Id);

            return Json(new { resultado = resultado }, new JsonSerializerSettings());
        }
    }
}
