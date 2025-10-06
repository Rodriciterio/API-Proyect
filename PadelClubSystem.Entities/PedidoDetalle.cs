using PadelClubSystem.Abstractions;

namespace PadelClubSystem.Entities
{
    public class PedidoDetalle : IEntidad
    {
        public PedidoDetalle()
        {
            Pedidos = new HashSet<Pedido>();
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Relaciones
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}
