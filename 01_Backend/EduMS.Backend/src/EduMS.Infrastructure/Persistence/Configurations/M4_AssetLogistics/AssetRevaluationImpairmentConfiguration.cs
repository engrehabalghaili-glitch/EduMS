using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetRevaluationImpairmentConfiguration : IEntityTypeConfiguration<AssetRevaluationImpairment>
{
    public void Configure(EntityTypeBuilder<AssetRevaluationImpairment> builder)
    {
        // Table Name
        builder.ToTable("asset_revaluation_impairment");

        // Property Configurations
        builder.Property(x => x.OldBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.OldAccumulatedDepreciation)
               .HasPrecision(18, 2);

        builder.Property(x => x.OldNetBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.NewValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.NewNetBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.DifferenceAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.ValuationFirmName)
               .HasMaxLength(100);

        builder.Property(x => x.ValuationReportNumber)
               .HasMaxLength(100);

        builder.Property(x => x.Reason)
               .HasMaxLength(500);

        builder.Property(x => x.AttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
