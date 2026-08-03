using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetFeasibilityComparisonConfiguration : IEntityTypeConfiguration<AssetFeasibilityComparison>
{
    public void Configure(EntityTypeBuilder<AssetFeasibilityComparison> builder)
    {
        // Table Name
        builder.ToTable("asset_feasibility_comparison");

        // Property Configurations
        builder.Property(x => x.RepairEstimate)
               .HasPrecision(18, 2);

        builder.Property(x => x.RepairEstimateBreakdownJson)
               .HasMaxLength(100);

        builder.Property(x => x.ReplacementCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.ReplacementCostBreakdownJson)
               .HasMaxLength(100);

        builder.Property(x => x.TcoAnalysisJson)
               .HasMaxLength(100);

        builder.Property(x => x.RecommendationReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
