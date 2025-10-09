using PadelClubSystem.Abstractions;
using PadelClubSystem.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Entities
{
    public class Cancha : IEntidad
    {
        public Cancha()
        {
            Reservas = new HashSet<Reserva>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la cancha es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Debe indicar el tipo de cancha.")]
        [StringLength(30, ErrorMessage = "El tipo no puede superar los 30 caracteres.")]
        public string Tipo { get; set; } = null!; // Ej: "Cubierta", "Descubierta", "Vidrio"
        [Range(0.01, 9999.99, ErrorMessage = "El precio por hora debe ser mayor que 0.")]
        public decimal PrecioHora { get; set; }
        public bool Activa { get; set; } = true;

        // Relaciones
        public virtual ICollection<Reserva> Reservas { get; set; }
       
    }
}
