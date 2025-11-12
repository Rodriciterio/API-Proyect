using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Entities.MicrosoftIdentity
{
    public class Role : IdentityRole<Guid>
    {
        [StringLength(100, ErrorMessage = "No debe superar los 100 caracteres")]
        public string? Descripcion { get; set; }
    }
}
