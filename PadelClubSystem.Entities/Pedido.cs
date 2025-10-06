using PadelClubSystem.Abstractions;

namespace PadelClubSystem.Entities
{
    public class Pedido : IEntidad
    {
        public Pedido()
        {
            Socios = new HashSet<Socio>();
            Detalles = new HashSet<PedidoDetalle>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public bool Pagado { get; set; } = false;

        // Relaciones

        public virtual ICollection<Socio> Socios { get; set; } = new List<Socio>();
        public virtual ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    }
}
