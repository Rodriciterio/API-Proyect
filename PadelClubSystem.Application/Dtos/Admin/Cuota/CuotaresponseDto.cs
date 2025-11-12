using System.ComponentModel.DataAnnotations.Schema;

namespace PadelClubSystem.Application.Dtos.Admin.Cuota
{
    public class CuotaResponseDto
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string CaducaEn { get; set; }
        public string Mes { get; set; }
        public string Anio { get; set; }
    }
}
