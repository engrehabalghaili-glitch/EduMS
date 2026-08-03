using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetStatusRecordConfiguration : IEntityTypeConfiguration<AssetStatusRecord>
{
    public void Configure(EntityTypeBuilder<AssetStatusRecord> builder)
    {
        // Table Name
        builder.ToTable("asset_status_record");

        // Property Configurations
        builder.Property(x => x.StatusCode)
               .HasMaxLength(100);

        builder.Property(x => x.StatusNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.StatusNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ColorCode)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
