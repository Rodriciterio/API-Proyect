using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Application.Dtos.Reserva;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ILogger<ReservasController> _logger;
        private readonly IApplication<Reserva> _reserva;
        private readonly IMapper _mapper;

        public ReservasController(
            ILogger<ReservasController> logger
            , IApplication<Reserva> reserva
            , IMapper mapper)
        {
            _logger = logger;
            _reserva = reserva;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ReservaResponseDto>>(_reserva.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Reserva reserva = _reserva.GetById(Id.Value);
            if (reserva is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReservaResponseDto>(reserva));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ReservaRequestDto reservaRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var reserva = _mapper.Map<Reserva>(reservaRequestDto);
            _reserva.Save(reserva);
            return Ok(reserva.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ReservaRequestDto reservaRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Reserva reservaBack = _reserva.GetById(Id.Value);
            if (reservaBack is null)
            { return NotFound(); }
            reservaBack = _mapper.Map<Reserva>(reservaRequestDto);
            _reserva.Save(reservaBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Reserva reservaBack = _reserva.GetById(Id.Value);
            if (reservaBack is null)
            { return NotFound(); }
            _reserva.Delete(reservaBack.Id);
            return Ok();
        }
    }
}
