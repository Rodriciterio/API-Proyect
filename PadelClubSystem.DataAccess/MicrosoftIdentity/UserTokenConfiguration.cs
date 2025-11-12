using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelClubSystem.Entities.MicrosoftIdentity;

namespace PadelClubSystem.DataAccess.MicrosoftIdentity
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.ToTable(nameof(UserToken));
        }
    }
}
