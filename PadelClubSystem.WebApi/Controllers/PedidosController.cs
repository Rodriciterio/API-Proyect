using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly IApplication<Pedido> _pedido;

        public PedidosController(ILogger<PedidosController> logger, IApplication<Pedido> pedido)
        {
            _logger = logger;
            _pedido = pedido;
        }

        [HttpGet]
        [Route("All")]
        public IActionResult All()
        {
            return Ok(_pedido.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public IActionResult ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Pedido pedido = _pedido.GetById(Id.Value);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Crear(Pedido pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _pedido.Save(pedido);
            return Ok(pedido.Id);
        }

        [HttpPut]
        public IActionResult Editar(int? Id, Pedido pedido)
        {
            if (!Id.HasValue)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Pedido pedidoBack = _pedido.GetById(Id.Value);
            if (pedidoBack == null)
                return NotFound();
            pedidoBack.Fecha = pedido.Fecha;
            pedidoBack.Total = pedido.Total;
            pedidoBack.Pagado = pedido.Pagado;
            pedidoBack.SocioId = pedido.SocioId;

            _pedido.Save(pedidoBack);
            return Ok(pedidoBack);
        }

        [HttpDelete]
        public IActionResult Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Pedido pedidoBack = _pedido.GetById(Id.Value);
            if (pedidoBack == null)
                return NotFound();

            _pedido.Delete(pedidoBack.Id);
            return Ok();
        }
    }
}
