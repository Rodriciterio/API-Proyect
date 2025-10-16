using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Application.Dtos.Cancha;
using PadelClubSystem.Application.Dtos.Socio;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasController : ControllerBase
    {
        private readonly ILogger<CanchasController> _logger;
        private readonly IApplication<Cancha> _cancha;
        private readonly IMapper _mapper;

        public CanchasController(
            ILogger<CanchasController> logger
            , IApplication<Cancha> cancha
            , IMapper mapper)
        {
            _logger = logger;
            _cancha = cancha;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<CanchaResponseDto>>(_cancha.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Cancha cancha = _cancha.GetById(Id.Value);
            if (cancha is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CanchaResponseDto>(cancha));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CanchaRequestDto canchaRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var cancha = _mapper.Map<Cancha>(canchaRequestDto);
            _cancha.Save(cancha);
            return Ok(cancha.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, CanchaRequestDto canchaRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Cancha canchaBack = _cancha.GetById(Id.Value);
            if (canchaBack is null)
            { return NotFound(); }
            canchaBack = _mapper.Map<Cancha>(canchaRequestDto);
            _cancha.Save(canchaBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Cancha canchaBack = _cancha.GetById(Id.Value);
            if (canchaBack is null)
            { return NotFound(); }
            _cancha.Delete(canchaBack.Id);
            return Ok();
        }
    }
}
