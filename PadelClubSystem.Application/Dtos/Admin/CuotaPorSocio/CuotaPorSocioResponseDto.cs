namespace PadelClubSystem.Application.Dtos.Admin.CuotaPorSocio
{
    public class CuotaPorSocioResponseDto
    {
        public int Id { get; set; }
        public string Socio { get; set; }
        public string Couta { get; set; }
        public decimal Valor { get; set; }
        public decimal Recargo { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaPago { get; set; }
    }
}
