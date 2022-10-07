using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.VinFast.Models;

namespace Web.VinFast.Data.FluentAPI
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(250).IsUnicode();
            builder.Property(a => a.Email).IsRequired().HasMaxLength(250);

        }
    }
}
