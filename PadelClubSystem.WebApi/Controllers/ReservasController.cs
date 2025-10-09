using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ILogger<ReservasController> _logger;
        private readonly IApplication<Reserva> _reserva;

        public ReservasController(ILogger<ReservasController> logger, IApplication<Reserva> reserva)
        {
            _logger = logger;
            _reserva = reserva;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_reserva.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Reserva reserva = _reserva.GetById(Id.Value);
            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        [HttpPost]
        public IActionResult Crear(Reserva reserva)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _reserva.Save(reserva);
            return Ok(reserva.Id);
        }

        [HttpPut]
        public IActionResult Editar(int? Id, Reserva reserva)
        {
            if (!Id.HasValue)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Reserva reservaBack = _reserva.GetById(Id.Value);
            if (reservaBack == null)
                return NotFound();
            reservaBack.FechaHora = reserva.FechaHora;
            reservaBack.DuracionMinutos = reserva.DuracionMinutos;
            reservaBack.Precio = reserva.Precio;
            reservaBack.SocioId = reserva.SocioId;
            reservaBack.CanchaId = reserva.CanchaId;

            _reserva.Save(reservaBack);
            return Ok(reservaBack);
        }

        [HttpDelete]
        public IActionResult Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Reserva reservaBack = _reserva.GetById(Id.Value);
            if (reservaBack == null)
                return NotFound();

            _reserva.Delete(reservaBack.Id);
            return Ok();
        }
    }
}
