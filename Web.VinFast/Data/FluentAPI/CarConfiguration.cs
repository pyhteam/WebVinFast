using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.VinFast.Models;

namespace Web.VinFast.Data.FluentAPI
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(250).IsUnicode();
            builder.Property(a => a.Image).IsRequired().HasMaxLength(250).IsUnicode();
            builder.Property(a => a.Description).IsRequired().IsUnicode();
            builder.Property(a => a.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(a => a.CarCategory).WithMany(a => a.Cars).HasForeignKey(a => a.CategoryId);

        }
    }
}
