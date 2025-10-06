using PadelClubSystem.Abstractions;
using PadelClubSystem.Entities.Entities;

namespace PadelClubSystem.Entities
{
    public class Cancha : IEntidad
    {
        public Cancha()
        {
            Reservas = new HashSet<Reserva>();
        }
        public int Id { get; set; }

        public int CanchaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!; // Ej: "Cubierta", "Descubierta", "Vidrio"
        public decimal PrecioHora { get; set; }
        public bool Activa { get; set; } = true;

        // Relaciones
        public virtual ICollection<Reserva> Reservas { get; set; }
       
    }
}
