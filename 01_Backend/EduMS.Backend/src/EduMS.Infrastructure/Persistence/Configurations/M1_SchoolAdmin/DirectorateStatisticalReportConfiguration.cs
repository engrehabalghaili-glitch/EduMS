using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DirectorateStatisticalReportConfiguration : IEntityTypeConfiguration<DirectorateStatisticalReport>
{
    public void Configure(EntityTypeBuilder<DirectorateStatisticalReport> builder)
    {
        // Table Name
        builder.ToTable("directorate_statistical_report");

        // Property Configurations
        builder.Property(x => x.ReportCode)
               .HasMaxLength(100);

        builder.Property(x => x.ReportTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.ReportTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.TargetAcademicYear)
               .HasMaxLength(100);

        builder.Property(x => x.StatisticalDataPayloadJson)
               .HasMaxLength(100);

        builder.Property(x => x.AnalyticalSummary)
               .HasMaxLength(100);

        builder.Property(x => x.RecommendationsText)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
