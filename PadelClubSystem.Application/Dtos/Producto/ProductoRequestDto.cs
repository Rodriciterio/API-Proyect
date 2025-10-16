using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Application.Dtos.Producto
{
    public class ProductoRequestDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; } = null!;
        [StringLength(150, ErrorMessage = "La descripción no puede superar los 150 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }
        public bool Activo { get; set; } = true;
    }
}
