using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Application.Dtos.Pago;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly ILogger<PagosController> _logger;
        private readonly IApplication<Pago> _pago;
        private readonly IMapper _mapper;

        public PagosController(
            ILogger<PagosController> logger
            , IApplication<Pago> pago
            , IMapper mapper)
        {
            _logger = logger;
            _pago = pago;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        [Authorize(Roles = "Administrador, Cliente, Socio")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<PagoResponseDto>>(_pago.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        [Authorize(Roles = "Administrador, Cliente, Socio")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Pago pago = _pago.GetById(Id.Value);
            if (pago is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PagoResponseDto>(pago));
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Crear(PagoRequestDto pagoRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var pago = _mapper.Map<Pago>(pagoRequestDto);
            _pago.Save(pago);
            return Ok(pago.Id);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar(int? Id, PagoRequestDto pagoRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Pago pagoBack = _pago.GetById(Id.Value);
            if (pagoBack is null)
            { return NotFound(); }
            pagoBack = _mapper.Map<Pago>(pagoRequestDto);
            _pago.Save(pagoBack);
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
            Pago pagoBack = _pago.GetById(Id.Value);
            if (pagoBack is null)
            { return NotFound(); }
            _pago.Delete(pagoBack.Id);
            return Ok();
        }
    }
}
