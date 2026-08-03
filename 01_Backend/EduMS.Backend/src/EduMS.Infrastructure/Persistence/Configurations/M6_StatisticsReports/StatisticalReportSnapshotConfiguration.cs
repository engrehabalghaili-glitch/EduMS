using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StatisticalReportSnapshotConfiguration : IEntityTypeConfiguration<StatisticalReportSnapshot>
{
    public void Configure(EntityTypeBuilder<StatisticalReportSnapshot> builder)
    {
        // Table Name
        builder.ToTable("STATISTICAL_REPORT_SNAPSHOT");

        // Property Configurations
        builder.Property(x => x.ReportCode)
               .HasMaxLength(100);

        builder.Property(x => x.ReportNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ReportCategory)
               .HasMaxLength(100);

        builder.Property(x => x.SnapshotPayloadJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


