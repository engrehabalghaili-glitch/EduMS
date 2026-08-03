using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetFeasibilityRiskAnalysisConfiguration : IEntityTypeConfiguration<AssetFeasibilityRiskAnalysis>
{
    public void Configure(EntityTypeBuilder<AssetFeasibilityRiskAnalysis> builder)
    {
        // Table Name
        builder.ToTable("asset_feasibility_risk_analysis");

        // Property Configurations
        builder.Property(x => x.AnalysisNumber)
               .HasMaxLength(100);

        builder.Property(x => x.OperationalRisks)
               .HasMaxLength(100);

        builder.Property(x => x.FinancialRisks)
               .HasMaxLength(100);

        builder.Property(x => x.RiskMitigationPlan)
               .HasMaxLength(100);

        builder.Property(x => x.UsefulLifeEstimateYears)
               .HasPrecision(18, 2);

        builder.Property(x => x.RoiEstimatePercent)
               .HasPrecision(18, 2);

        builder.Property(x => x.NpvEstimate)
               .HasPrecision(18, 2);

        builder.Property(x => x.AlternativeSolutions)
               .HasMaxLength(100);

        builder.Property(x => x.RecommendationReason)
               .HasMaxLength(500);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
