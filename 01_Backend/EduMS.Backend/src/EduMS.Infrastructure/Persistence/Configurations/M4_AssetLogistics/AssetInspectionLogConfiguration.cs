using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetInspectionLogConfiguration : IEntityTypeConfiguration<AssetInspectionLog>
{
    public void Configure(EntityTypeBuilder<AssetInspectionLog> builder)
    {
        // Table Name
        builder.ToTable("asset_inspection_log");

        // Property Configurations
        builder.Property(x => x.RelatedTransactionType)
               .HasMaxLength(100);

        builder.Property(x => x.DamageDetails)
               .HasMaxLength(100);

        builder.Property(x => x.DamagePhotosJson)
               .HasMaxLength(100);

        builder.Property(x => x.MissingPartsJson)
               .HasMaxLength(100);

        builder.Property(x => x.RecommendedAction)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedRepairCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
