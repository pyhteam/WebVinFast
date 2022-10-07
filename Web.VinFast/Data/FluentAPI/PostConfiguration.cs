using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Web.VinFast.Models;

namespace Web.VinFast.Data.FluentAPI
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200).IsUnicode();
            builder.Property(a => a.Content).IsRequired().IsUnicode();
            builder.Property(a => a.Image).IsRequired().IsUnicode();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.HasOne(a => a.User).WithMany(a => a.Post).HasForeignKey(a => a.UserId);
        }
    }
}
