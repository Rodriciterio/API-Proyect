using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadelClubSystem.Entities.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }
        public bool Pagado { get; set; } = false;

        // Relaciones
        public int SocioId { get; set; }
        public Socio Socio { get; set; } = null!;

        public ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    }
}
