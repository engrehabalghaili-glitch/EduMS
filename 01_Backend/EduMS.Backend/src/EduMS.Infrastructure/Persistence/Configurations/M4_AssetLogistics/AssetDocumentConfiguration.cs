using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetDocumentConfiguration : IEntityTypeConfiguration<AssetDocument>
{
    public void Configure(EntityTypeBuilder<AssetDocument> builder)
    {
        // Table Name
        builder.ToTable("asset_document");

        // Property Configurations
        builder.Property(x => x.DocType)
               .HasMaxLength(100);

        builder.Property(x => x.DocCode)
               .HasMaxLength(100);

        builder.Property(x => x.DocNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.FileName)
               .HasMaxLength(100);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.FileType)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
