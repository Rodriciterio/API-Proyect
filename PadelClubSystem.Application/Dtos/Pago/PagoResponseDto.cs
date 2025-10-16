using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Pago
{
    public class PagoResponseDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public decimal MontoTotal { get; set; }
        public string Metodo { get; set; } = "Efectivo";
    }
}
