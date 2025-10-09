using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly IApplication<Producto> _producto;

        public ProductosController(ILogger<ProductosController> logger, IApplication<Producto> producto)
        {
            _logger = logger;
            _producto = producto;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_producto.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Producto producto = _producto.GetById(Id.Value);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _producto.Save(producto);
            return Ok(producto.Id);
        }

        [HttpPut]
        public IActionResult Editar(int? Id, Producto producto)
        {
            if (!Id.HasValue)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Producto productoBack = _producto.GetById(Id.Value);
            if (productoBack == null)
                return NotFound();
            productoBack.Nombre = producto.Nombre;
            productoBack.Descripcion = producto.Descripcion;
            productoBack.Precio = producto.Precio;
            productoBack.Stock = producto.Stock;
            productoBack.Activo = producto.Activo;

            _producto.Save(productoBack);
            return Ok(productoBack);
        }

        [HttpDelete]
        public IActionResult Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Producto productoBack = _producto.GetById(Id.Value);
            if (productoBack == null)
                return NotFound();

            _producto.Delete(productoBack.Id);
            return Ok();
        }
    }
}
