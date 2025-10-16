using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Pago
{
    public class PagoRequestDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        [Range(0.01, 99999999.99, ErrorMessage = "El monto total debe ser mayor que 0.")]
        public decimal MontoTotal { get; set; }
        [Required(ErrorMessage = "Debe especificar el método de pago.")]
        [StringLength(30, ErrorMessage = "El método no puede superar los 30 caracteres.")]
        public string Metodo { get; set; } = "Efectivo";
    }
}
