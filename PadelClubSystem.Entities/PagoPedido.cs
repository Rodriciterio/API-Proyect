using PadelClubSystem.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadelClubSystem.Entities
{
    public class PagoPedido : IEntidad
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Pago))]
        public int IdPago { get; set; }

        [Required]
        [ForeignKey(nameof(Pedido))]
        public int IdPedido { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Monto { get; set; }

        // Relaciones
        public virtual Pago Pago { get; set; } = null!;
        public virtual Pedido Pedido { get; set; } = null!;
    }
}
