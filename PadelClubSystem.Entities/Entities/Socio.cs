namespace PadelClubSystem.Entities.Entities
{
    public class Socio
    {
        public int SocioId { get; set; }

        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
