using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly ILogger<SociosController> _logger;
        private readonly IApplication<Socio> _socio;
        public SociosController(ILogger<SociosController> logger, IApplication<Socio> socio)
        {
            _logger = logger;
            _socio = socio;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_socio.GetAll());
        }

        [HttpGet]
        [Route("ById")]
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
            return Ok(socio);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Socio socio)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            _socio.Save(socio);
            return Ok(socio.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Socio socio)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Socio socioBack = _socio.GetById(Id.Value);
            if (socioBack is null)
            { return NotFound(); }
            socioBack.Nombre = socio.Nombre;
            socioBack.Apellido = socio.Apellido;
            socioBack.Email = socio.Email;
            _socio.Save(socioBack);
            return Ok(socioBack);
        }

        [HttpDelete]
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
