using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Application.Dtos.Socio;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly ILogger<SociosController> _logger;
        private readonly IApplication<Socio> _socio;
        private readonly IMapper _mapper;
        public SociosController(
            ILogger<SociosController> logger
            , IApplication<Socio> socio
            , IMapper mapper)
        {
            _logger = logger;
            _socio = socio;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Administrador, Cliente")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<SocioResponseDto>>(_socio.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        [Authorize(Roles = "Administrador, Cliente")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Socio socio = _socio.GetById(Id.Value);
            if (socio is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SocioResponseDto>(socio));
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Crear(SocioRequestDto socioRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var socio = _mapper.Map<Socio>(socioRequestDto);
            _socio.Save(socio);
            return Ok(socio.Id);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar(int? Id, SocioRequestDto socioRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Socio socioBack = _socio.GetById(Id.Value);
            if (socioBack is null)
            { return NotFound(); }
            socioBack = _mapper.Map<Socio>(socioRequestDto);
            _socio.Save(socioBack);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Socio socioBack = _socio.GetById(Id.Value);
            if (socioBack is null)
            { return NotFound(); }
            _socio.Delete(socioBack.Id);
            return Ok();
        }
    }
}
