using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StatisticsReportsArchiveConfiguration : IEntityTypeConfiguration<StatisticsReportsArchive>
{
    public void Configure(EntityTypeBuilder<StatisticsReportsArchive> builder)
    {
        // Table Name
        builder.ToTable("STATISTICS_REPORTS_ARCHIVE");

        // Property Configurations
        builder.Property(x => x.SourceReportType)
               .HasMaxLength(100);

        builder.Property(x => x.FilePath)
               .HasMaxLength(100);

        builder.Property(x => x.DisposalMethod)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


