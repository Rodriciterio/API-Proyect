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
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;
    }
}
