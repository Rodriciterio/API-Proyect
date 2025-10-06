using PadelClubSystem.Abstractions;
using System.Collections.ObjectModel;

namespace PadelClubSystem.Entities.Entities
{
    public class Reserva : IEntidad
    {
        public Reserva()
        {
            Canchas = new HashSet<Cancha>();
            Socios = new HashSet<Socio>();
        }

        public int Id { get; set; }

        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; } = 60;
        public decimal Precio { get; set; }

        // Relaciones
        public virtual ICollection<Socio> Socios { get; set; }
        public virtual ICollection<Cancha> Canchas { get; set; }
        
    }
}
