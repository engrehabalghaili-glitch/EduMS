using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class GapAnalysisReportConfiguration : IEntityTypeConfiguration<GapAnalysisReport>
{
    public void Configure(EntityTypeBuilder<GapAnalysisReport> builder)
    {
        // Table Name
        builder.ToView("gap_analysis_report_view");

        // Property Configurations
        builder.Property(x => x.AnalysisNumber)
               .HasMaxLength(100);

        builder.Property(x => x.AnalysisType)
               .HasMaxLength(100);

        builder.Property(x => x.GapValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.GapPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.GapType)
               .HasMaxLength(100);

        builder.Property(x => x.Recommendation)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


