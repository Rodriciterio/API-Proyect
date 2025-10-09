using PadelClubSystem.Abstractions;
using PadelClubSystem.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace PadelClubSystem.Entities
{
    public class Socio : IEntidad
    {
        public Socio()
        {
            TorneosSocios = new HashSet<TorneoSocio>();
            Reservas = new HashSet<Reserva>();
            Pedidos = new HashSet<Pedido>();
        }
        public int Id { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [StringLength(30)]
        public string Apellido { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [StringLength(20)]
        public string Telefono { get; set; } = null!;
        public DateTime FechaAlta { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; } 
        public virtual ICollection<TorneoSocio> TorneosSocios { get; set; }
    }
}
