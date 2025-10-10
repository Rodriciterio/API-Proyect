using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly ILogger<PagosController> _logger;
        private readonly IApplication<Pago> _pago;

        public PagosController(ILogger<PagosController> logger, IApplication<Pago> pago)
        {
            _logger = logger;
            _pago = pago;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_pago.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Pago pago = _pago.GetById(Id.Value);
            if (pago == null)
                return NotFound();

            return Ok(pago);
        }

        [HttpPost]
        public IActionResult Crear(Pago pago)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _pago.Save(pago);
            return Ok(pago.Id);
        }

        [HttpPut]
        public IActionResult Editar(int? Id, Pago pago)
        {
            if (!Id.HasValue)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Pago pagoBack = _pago.GetById(Id.Value);
            if (pagoBack == null)
                return NotFound();

            pagoBack.Fecha = pago.Fecha;
            pagoBack.MontoTotal = pago.MontoTotal;
            pagoBack.Metodo = pago.Metodo;

            _pago.Save(pagoBack);
            return Ok(pagoBack);
        }

        [HttpDelete]
        public IActionResult Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Pago pagoBack = _pago.GetById(Id.Value);
            if (pagoBack == null)
                return NotFound();

            _pago.Delete(pagoBack.Id);
            return Ok();
        }
    }
}
