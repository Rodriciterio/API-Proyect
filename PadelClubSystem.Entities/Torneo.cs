using PadelClubSystem.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Entities
{
    public class Torneo : IEntidad
    {
        public Torneo()
        {
            TorneosSocios = new HashSet<TorneoSocio>();
        }

        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaInicio { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaFin { get; set; }
        [Range(0.01, 999999.99)]
        public decimal CostoInscripcion { get; set; }

        // Relaciones
        public virtual ICollection<TorneoSocio> TorneosSocios { get; set; } 
    }
}
