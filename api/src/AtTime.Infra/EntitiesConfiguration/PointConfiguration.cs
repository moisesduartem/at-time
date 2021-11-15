using AtTime.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtTime.Infra.EntitiesConfiguration
{
    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Time).IsRequired();
            builder.Property(x => x.AuthorId).IsRequired();

            builder.HasOne(x => x.Author).WithMany(x => x.Points).HasForeignKey(x => x.AuthorId);
        }
    }
}
