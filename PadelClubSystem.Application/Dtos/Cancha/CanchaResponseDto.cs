using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Cancha
{
    public class CanchaResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!; // Ej: "Cubierta", "Descubierta", "Vidrio"
        public decimal PrecioHora { get; set; }
        public bool Activa { get; set; } = true;
    }
}
