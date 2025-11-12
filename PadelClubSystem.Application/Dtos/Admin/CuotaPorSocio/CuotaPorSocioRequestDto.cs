using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Admin.CuotaPorSocio
{
    public class CuotaPorSocioRequestDto
    {
        public int Id { get; set; }
        public int IdSocio { get; set; }
        public int IdCouta { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaPago { get; set; }
    }
}
