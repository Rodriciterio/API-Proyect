using PadelClubSystem.Abstractions;

namespace PadelClubSystem.Entities
{
    public class Pago : IEntidad
    {
        public Pago()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public decimal Monto { get; set; }
        public string Metodo { get; set; } = "Efectivo"; 

        // Relaciones
        public virtual ICollection<Pedido> Pedidos { get; set; } 

    }
}
