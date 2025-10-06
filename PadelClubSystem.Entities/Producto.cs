using PadelClubSystem.Abstractions;

namespace PadelClubSystem.Entities
{
    public class Producto : IEntidad
    {
        public Producto()
        {
            PedidosDetalles = new HashSet<PedidoDetalle>();
        }
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; } = true;

        // Relaciones
        public virtual ICollection<PedidoDetalle> PedidosDetalles { get; set; }
    }
}
