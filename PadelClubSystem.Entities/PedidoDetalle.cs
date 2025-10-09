using PadelClubSystem.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadelClubSystem.Entities
{
    public class PedidoDetalle : IEntidad
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe especificar la cantidad.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "Debe indicar el precio unitario.")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio unitario debe ser mayor que 0.")]
        public decimal PrecioUnitario { get; set; }

        // Relaciones
        [ForeignKey(nameof(Pedido))]
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; } = null!;

        [ForeignKey(nameof(Producto))]
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; } = null!;

    }
}
