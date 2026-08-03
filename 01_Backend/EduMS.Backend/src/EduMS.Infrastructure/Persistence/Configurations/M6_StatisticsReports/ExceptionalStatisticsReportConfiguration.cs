using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ExceptionalStatisticsReportConfiguration : IEntityTypeConfiguration<ExceptionalStatisticsReport>
{
    public void Configure(EntityTypeBuilder<ExceptionalStatisticsReport> builder)
    {
        // Table Name
        builder.ToTable("EXCEPTIONAL_STAT_REPORT");

        // Property Configurations
        builder.Property(x => x.ReportNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TotalDamageCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.EmergencySummaryJson)
               .HasMaxLength(100);

        builder.Property(x => x.ClosureSummaryJson)
               .HasMaxLength(100);

        builder.Property(x => x.AwardSummaryJson)
               .HasMaxLength(100);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


