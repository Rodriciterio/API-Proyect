using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Socio
{
    public class SocioRequestDto
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        [StringLength(30)]
        public string Apellido { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefono { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FechaBaja { get; set; }
    }
}
