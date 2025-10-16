using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Application.Dtos.Socio;
using PadelClubSystem.Application.Dtos.Torneo;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneosController : ControllerBase
    {
        private readonly ILogger<TorneosController> _logger;
        private readonly IApplication<Torneo> _torneo;
        private readonly IMapper _mapper;
        public TorneosController(
            ILogger<TorneosController> logger
            , IApplication<Torneo> torneo
            , IMapper mapper)
        {
            _logger = logger;
            _torneo = torneo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<TorneoResponseDto>>(_torneo.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Torneo torneo = _torneo.GetById(Id.Value);
            if (torneo is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TorneoResponseDto>(torneo));
        }

        [HttpPost]
        public async Task <IActionResult> Crear(TorneoRequestDto torneoRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var torneo = _mapper.Map<Torneo>(torneoRequestDto);
            _torneo.Save(torneo);
            return Ok(torneo.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, TorneoRequestDto torneoRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Torneo torneoBack = _torneo.GetById(Id.Value);
            if (torneoBack is null)
            { return NotFound(); }
            torneoBack = _mapper.Map<Torneo>(torneoRequestDto);
            _torneo.Save(torneoBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Torneo torneoBack = _torneo.GetById(Id.Value);
            if (torneoBack is null)
            { return NotFound(); }
            _torneo.Delete(torneoBack.Id);
            return Ok();
        }
    }
}
