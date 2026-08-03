using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ComparativeReportConfiguration : IEntityTypeConfiguration<ComparativeReport>
{
    public void Configure(EntityTypeBuilder<ComparativeReport> builder)
    {
        // Table Name
        builder.ToTable("COMPARATIVE_REPORT");

        // Property Configurations
        builder.Property(x => x.ReportNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ComparisonTitle)
               .HasMaxLength(100);

        builder.Property(x => x.FirstPeriodLabel)
               .HasMaxLength(100);

        builder.Property(x => x.FirstPeriodStart)
               .HasMaxLength(100);

        builder.Property(x => x.FirstPeriodEnd)
               .HasMaxLength(100);

        builder.Property(x => x.SecondPeriodLabel)
               .HasMaxLength(100);

        builder.Property(x => x.SecondPeriodStart)
               .HasMaxLength(100);

        builder.Property(x => x.SecondPeriodEnd)
               .HasMaxLength(100);

        builder.Property(x => x.ComparisonType)
               .HasMaxLength(100);

        builder.Property(x => x.KpiComparedJson)
               .HasMaxLength(100);

        builder.Property(x => x.ComparisonDataJson)
               .HasMaxLength(100);

        builder.Property(x => x.AutoInsights)
               .HasMaxLength(100);

        builder.Property(x => x.Summary)
               .HasMaxLength(100);

        builder.Property(x => x.FileFormat)
               .HasMaxLength(100);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


