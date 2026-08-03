using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SystemReportConfiguration : IEntityTypeConfiguration<SystemReport>
{
    public void Configure(EntityTypeBuilder<SystemReport> builder)
    {
        // Table Name
        builder.ToTable("SYSTEM_REPORT");

        // Property Configurations
        builder.Property(x => x.ReportType)
               .HasMaxLength(100);

        builder.Property(x => x.ReportSubType)
               .HasMaxLength(100);

        builder.Property(x => x.ReportTitle)
               .HasMaxLength(100);

        builder.Property(x => x.PeriodStart)
               .HasMaxLength(100);

        builder.Property(x => x.PeriodEnd)
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


