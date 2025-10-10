using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasController : ControllerBase
    {
        private readonly ILogger<CanchasController> _logger;
        private readonly IApplication<Cancha> _cancha;

        public CanchasController(ILogger<CanchasController> logger, IApplication<Cancha> cancha)
        {
            _logger = logger;
            _cancha = cancha;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_cancha.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Cancha cancha = _cancha.GetById(Id.Value);
            if (cancha == null)
                return NotFound();

            return Ok(cancha);
        }

        [HttpPost]
        public IActionResult Crear(Cancha cancha)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _cancha.Save(cancha);
            return Ok(cancha.Id);
        }

        [HttpPut]
        public IActionResult Editar(int? Id, Cancha cancha)
        {
            if (!Id.HasValue)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Cancha canchaBack = _cancha.GetById(Id.Value);
            if (canchaBack == null)
                return NotFound();

            canchaBack.Nombre = cancha.Nombre;
            canchaBack.Tipo = cancha.Tipo;
            canchaBack.PrecioHora = cancha.PrecioHora;
            canchaBack.Activa = cancha.Activa;

            _cancha.Save(canchaBack);
            return Ok(canchaBack);
        }

        [HttpDelete]
        public IActionResult Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Cancha canchaBack = _cancha.GetById(Id.Value);
            if (canchaBack == null)
                return NotFound();

            _cancha.Delete(canchaBack.Id);
            return Ok();
        }
    }
}
