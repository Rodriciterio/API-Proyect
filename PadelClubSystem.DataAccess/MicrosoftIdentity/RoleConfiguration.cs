using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelClubSystem.Entities.MicrosoftIdentity;

namespace PadelClubSystem.DataAccess.MicrosoftIdentity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));
        }
    }
}
