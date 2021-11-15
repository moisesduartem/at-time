using AtTime.Core.Enums;
using AtTime.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtTime.Infra.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Role).HasDefaultValue(UserRole.Regular);

            builder.HasMany(x => x.Points).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
        }
    }
}
