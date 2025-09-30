namespace PadelClubSystem.Entities.Entities
{
    public class Reserva
    {
        public int ReservaId { get; set; }

        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; } = 60;
        public decimal Precio { get; set; }

        // Relaciones
        public int SocioId { get; set; }
        public Socio Socio { get; set; } = null!;
        public int CanchaId { get; set; }
        public Cancha Cancha { get; set; } = null!;
    }
}
