using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Torneo
{
    public class TorneoRequestDto
    {
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
    }
}
