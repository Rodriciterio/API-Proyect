using PadelClubSystem.Abstractions;

namespace PadelClubSystem.Entities
{
    public class Torneo : IEntidad
    {
        public Torneo()
        {
            TorneosSocios = new HashSet<TorneoSocio>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal CostoInscripcion { get; set; }

        // Relaciones
        public virtual ICollection<TorneoSocio> TorneosSocios { get; set; } 
    }
}
