using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Reserva
{
    public class ReservaRequestDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe indicar la fecha y hora de la reserva.")]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }
        [Range(30, 180, ErrorMessage = "La duración debe ser entre 30 y 180 minutos.")]
        public int DuracionMinutos { get; set; } = 60;
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }
    }
}
