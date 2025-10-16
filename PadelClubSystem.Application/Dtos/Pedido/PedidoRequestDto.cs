using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Pedido
{
    public class PedidoRequestDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        [Range(0, 99999999.99, ErrorMessage = "El total no puede ser negativo.")]
        public decimal Total { get; set; }
        public bool Pagado { get; set; } = false;
    }
}
