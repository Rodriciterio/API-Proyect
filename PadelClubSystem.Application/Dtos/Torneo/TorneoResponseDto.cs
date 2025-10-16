using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Torneo
{
    public class TorneoResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal CostoInscripcion { get; set; }
    }
}
