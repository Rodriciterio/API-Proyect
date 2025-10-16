using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Pedido
{
    public class PedidoResponseDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public bool Pagado { get; set; } = false;
    }
}
