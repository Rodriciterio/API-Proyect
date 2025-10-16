namespace PadelClubSystem.Application.Dtos.Socio
{
    public class SocioResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
    }
}
