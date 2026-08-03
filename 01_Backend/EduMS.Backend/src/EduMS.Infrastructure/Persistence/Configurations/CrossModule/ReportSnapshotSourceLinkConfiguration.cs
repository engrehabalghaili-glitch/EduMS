using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ReportSnapshotSourceLinkConfiguration : IEntityTypeConfiguration<ReportSnapshotSourceLink>
{
    public void Configure(EntityTypeBuilder<ReportSnapshotSourceLink> builder)
    {
        // Table Name
        builder.ToTable("report_snapshot_source_link");

        // Property Configurations
        builder.Property(x => x.SourceModule)
               .HasMaxLength(100);

        builder.Property(x => x.SourceEntityType)
               .HasMaxLength(100);

        builder.Property(x => x.AggregationDescription)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
