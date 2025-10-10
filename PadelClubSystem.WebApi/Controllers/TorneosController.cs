using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneosController : ControllerBase
    {
        private readonly ILogger<TorneosController> _logger;
        private readonly IApplication<Torneo> _torneo;

        public TorneosController(ILogger<TorneosController> logger, IApplication<Torneo> torneo)
        {
            _logger = logger;
            _torneo = torneo;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_torneo.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();

            Torneo torneo = _torneo.GetById(Id.Value);
            if (torneo == null) return NotFound();

            return Ok(torneo);
        }

        [HttpPost]
        public IActionResult Crear(Torneo torneo)
        {
            if (!ModelState.IsValid) return BadRequest();

            _torneo.Save(torneo);
            return Ok(torneo.Id);
        }

        [HttpPut]
        public IActionResult Editar(int? Id, Torneo torneo)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            Torneo torneoBack = _torneo.GetById(Id.Value);
            if (torneoBack == null) return NotFound();

            torneoBack.Nombre = torneo.Nombre;
            torneoBack.FechaInicio = torneo.FechaInicio;
            torneoBack.FechaFin = torneo.FechaFin;
            torneoBack.CostoInscripcion = torneo.CostoInscripcion;

            _torneo.Save(torneoBack);
            return Ok(torneoBack);
        }

        [HttpDelete]
        public IActionResult Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();

            Torneo torneoBack = _torneo.GetById(Id.Value);
            if (torneoBack == null) return NotFound();

            _torneo.Delete(torneoBack.Id);
            return Ok();
        }
    }
}
