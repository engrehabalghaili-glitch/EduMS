using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class TrendAnalysisResultConfiguration : IEntityTypeConfiguration<TrendAnalysisResult>
{
    public void Configure(EntityTypeBuilder<TrendAnalysisResult> builder)
    {
        // Table Name
        builder.ToTable("TREND_ANALYSIS_RESULT");

        // Property Configurations
        builder.Property(x => x.StudyPeriod)
               .HasMaxLength(100);

        builder.Property(x => x.StartYear)
               .HasMaxLength(100);

        builder.Property(x => x.EndYear)
               .HasMaxLength(100);

        builder.Property(x => x.KpiCode)
               .HasMaxLength(100);

        builder.Property(x => x.HistoricalValuesJson)
               .HasMaxLength(100);

        builder.Property(x => x.TrendDirection)
               .HasMaxLength(100);

        builder.Property(x => x.Slope)
               .HasPrecision(18, 2);

        builder.Property(x => x.CorrelationCoefficient)
               .HasPrecision(18, 2);

        builder.Property(x => x.ForecastedValueNext1Year)
               .HasPrecision(18, 2);

        builder.Property(x => x.ForecastedValueNext2Year)
               .HasPrecision(18, 2);

        builder.Property(x => x.ConfidenceLevel)
               .HasPrecision(18, 2);

        builder.Property(x => x.LowerBound)
               .HasPrecision(18, 2);

        builder.Property(x => x.UpperBound)
               .HasPrecision(18, 2);

        builder.Property(x => x.ForecastingMethod)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


