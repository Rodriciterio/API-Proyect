using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PadelClubSystem.Entities;
using PadelClubSystem.Entities.MicrosoftIdentity;

namespace PadelClubSystem.DataAccess
{
    public class DbDataAccess : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public virtual DbSet<Cancha> Canchas { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoDetalle> PedidosDetalles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Anio> Anios { get; set; }
        public virtual DbSet<Mes> Meses { get; set; }
        public virtual DbSet<Cuota> Cuotas { get; set; }
        public virtual DbSet<Socio> Socios { get; set; }
        public virtual DbSet<Torneo> Torneos { get; set; }
        public virtual DbSet<CuotaPorSocio> CoutasPorSocios { get; set; }
        public virtual DbSet<TorneoSocio> TorneosSocios { get; set; }
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
