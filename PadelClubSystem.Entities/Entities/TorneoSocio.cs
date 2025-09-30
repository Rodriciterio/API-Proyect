using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadelClubSystem.Entities.Entities
{
    public class TorneoSocio
    {
        public int TorneoId { get; set; }
        public Torneo Torneo { get; set; } = null!;

        public int SocioId { get; set; }
        public Socio Socio { get; set; } = null!;
    }
}
