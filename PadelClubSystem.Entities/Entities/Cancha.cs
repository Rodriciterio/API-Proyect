namespace PadelClubSystem.Entities.Entities
{
    public class Cancha
    {
        public int CanchaId { get; set; }

        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!; // Ej: "Cubierta", "Descubierta", "Vidrio"
        public decimal PrecioHora { get; set; }
        public bool Activa { get; set; } = true;

        // Relaciones
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
