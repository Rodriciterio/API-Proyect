using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PadelClubSystem.Application;
using PadelClubSystem.Entities;

namespace PadelClubSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosPedidosController : ControllerBase
    {
        private readonly ILogger<PagosPedidosController> _logger;
        private readonly IApplication<PagoPedido> _pagoPedido;
        private readonly IApplication<Pago> _pago;
        private readonly IApplication<Pedido> _pedido;

        public PagosPedidosController(ILogger<PagosPedidosController> logger,
                                    IApplication<PagoPedido> pagoPedido,
                                    IApplication<Pago> pago,
                                    IApplication<Pedido> pedido)
        {
            _logger = logger;
            _pagoPedido = pagoPedido;
            _pago = pago;
            _pedido = pedido;
        }

        [HttpGet("All")]
        public IActionResult All() => Ok(_pagoPedido.GetAll());

        [HttpGet("ById")]
        public IActionResult ById(int? Id)
        {
            if (!Id.HasValue) return BadRequest();
            var pagoPedido = _pagoPedido.GetById(Id.Value);
            if (pagoPedido == null) return NotFound();
            return Ok(pagoPedido);
        }

        [HttpPost]
        public IActionResult Crear(PagoPedido pagoPedido)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pagoExistente = _pago.GetById(pagoPedido.IdPago);
            var pedidoExistente = _pedido.GetById(pagoPedido.IdPedido);
            if (pagoExistente == null || pedidoExistente == null)
                return BadRequest("Pago o Pedido no existen.");

            _pagoPedido.Save(pagoPedido);
            var pagosDelPedido = _pagoPedido.GetAll().Where(pp => pp.IdPedido == pagoPedido.IdPedido).Sum(pp => pp.Monto);
            if (pagosDelPedido >= pedidoExistente.Total)
            {
                pedidoExistente.Pagado = true;
                _pedido.Save(pedidoExistente);
            }

            return Ok(pagoPedido.Id);
        }

        [HttpPut]
        public IActionResult Editar(int? Id, PagoPedido pagoPedido)
        {
            if (!Id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pagoPedidoBack = _pagoPedido.GetById(Id.Value);
            if (pagoPedidoBack == null) return NotFound();

            pagoPedidoBack.IdPago = pagoPedido.IdPago;
            pagoPedidoBack.IdPedido = pagoPedido.IdPedido;
            pagoPedidoBack.Monto = pagoPedido.Monto;

            _pagoPedido.Save(pagoPedidoBack);
            return Ok(pagoPedidoBack);
        }

        [HttpDelete]
        public IActionResult Borrar(int? Id)
        {
            if (!Id.HasValue) return BadRequest();

            var pagoPedidoBack = _pagoPedido.GetById(Id.Value);
            if (pagoPedidoBack == null) return NotFound();

            _pagoPedido.Delete(pagoPedidoBack.Id);
            return Ok();
        }
    }
}
