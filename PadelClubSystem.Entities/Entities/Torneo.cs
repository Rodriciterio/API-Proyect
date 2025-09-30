namespace PadelClubSystem.Entities.Entities
{
    public class Torneo
    {
        public int TorneoId { get; set; }

        public string Nombre { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal CostoInscripcion { get; set; }

        // Relaciones
        public ICollection<TorneoSocio> Participantes { get; set; } = new List<TorneoSocio>();
    }
}
