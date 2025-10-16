using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Reserva
{
    public class ReservaResponseDto
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; } = 60;
        public decimal Precio { get; set; }
    }
}
