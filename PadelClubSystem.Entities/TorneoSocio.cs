using PadelClubSystem.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace PadelClubSystem.Entities
{
    public class TorneoSocio : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Torneo))]
        public int IdTorneo { get; set; }
        [ForeignKey(nameof(Socio))]
        public int IdSocio { get; set; }

        public virtual Torneo Torneo { get; set; }
        public virtual Socio Socio { get; set; }
    }
}
