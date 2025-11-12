using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Admin.Cuota
{
    public class CuotaRequestDto
    {
        public decimal Valor { get; set; }
        [DataType(DataType.Date)]
        public DateTime CaducaEn { get; set; }
        public int IdAnio { get; set; }
    }
}
