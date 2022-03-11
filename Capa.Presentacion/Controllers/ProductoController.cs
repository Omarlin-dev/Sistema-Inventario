using Capa.Negocio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using Capa.Entidades;
using Capa.Entidades.ViewModel;
using Newtonsoft.Json;
using System.Linq;

namespace Capa.Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IMapper mapper;
        private CnProducto objProducto = new CnProducto();

        public ProductoController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult ProductoIndex()
        {
            return View();
        }

        public async Task<JsonResult> ObtenerProducto()
        {
            var TodosProductoDatos = await objProducto.GetProductos();

            var todosProductoMostrar = (from d in TodosProductoDatos
                                        select new ProductoViewModel
                                        {
                                            Idproducto = d.Idproducto,
                                            Nombre = d.Nombre,
                                            Precio = d.Precio,
                                            Provedor = d.Provedor,
                                            Cantidad = d.Cantidad,
                                            ProvedorNavigation = new ProveedorViewModel()
                                            {
                                                Nombre = d.ProvedorNavigation.Nombre,
                                                Tipo = d.ProvedorNavigation.Tipo
                                            }
                                        }).ToList();
            

            return Json(new { data = todosProductoMostrar }, new JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult GuadarProducto([FromBody] ProductoViewModel productoModel)
        {
            object resultado = false;

            var producto = mapper.Map<Producto>(productoModel); 

            if (!ModelState.IsValid)
            {
                return Json(new { resultado = resultado }, new JsonSerializerSettings());
            }

            if (producto != null)
            {
                if (producto.Idproducto == 0)
                {
                    resultado = objProducto.AgregarProducto(producto);
                }
                else
                {
                    resultado = objProducto.EditarProducto(producto);
                }
            }

            return Json(new { resultado = resultado }, new JsonSerializerSettings());
        }

        [HttpGet]
        public async Task<JsonResult> EliminarProducto(int Id)
        {
            bool resultado = await objProducto.EliminarProducto(Id);

            return Json(new { resultado = resultado }, new JsonSerializerSettings());
        }
    }
}
