using PadelClubSystem.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadelClubSystem.Entities
{
    public class Pedido : IEntidad
    {

        public Pedido()
        {
            Detalles = new HashSet<PedidoDetalle>();
            PagosPedidos = new HashSet<PagoPedido>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        [Range(0, 99999999.99, ErrorMessage = "El total no puede ser negativo.")]
        public decimal Total { get; set; }
        public bool Pagado { get; set; } = false;

        // Relaciones
        [ForeignKey(nameof(Socio))]
        public int SocioId { get; set; }
        public virtual Socio Socio { get; set; } = null!;

        public virtual ICollection<PedidoDetalle> Detalles { get; set; }
        public virtual ICollection<PagoPedido> PagosPedidos { get; set; }
    }
}
