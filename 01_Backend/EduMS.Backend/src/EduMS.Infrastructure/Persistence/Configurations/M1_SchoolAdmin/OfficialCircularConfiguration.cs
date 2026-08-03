using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class OfficialCircularConfiguration : IEntityTypeConfiguration<OfficialCircular>
{
    public void Configure(EntityTypeBuilder<OfficialCircular> builder)
    {
        // Table Name
        builder.ToTable("official_circular");

        // Property Configurations
        builder.Property(x => x.CircularNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.TitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.IssuerName)
               .HasMaxLength(100);

        builder.Property(x => x.ContentBody)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentFileUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
