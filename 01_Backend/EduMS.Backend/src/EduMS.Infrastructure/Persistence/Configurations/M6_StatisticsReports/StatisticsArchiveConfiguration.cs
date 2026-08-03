using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StatisticsArchiveConfiguration : IEntityTypeConfiguration<StatisticsArchive>
{
    public void Configure(EntityTypeBuilder<StatisticsArchive> builder)
    {
        // Table Name
        builder.ToTable("STATISTICS_ARCHIVE");

        // Property Configurations
        builder.Property(x => x.ArchivedYear)
               .HasMaxLength(100);

        builder.Property(x => x.FinalDataSnapshotJson)
               .HasMaxLength(100);

        builder.Property(x => x.StudentSnapshotJson)
               .HasMaxLength(100);

        builder.Property(x => x.StaffSnapshotJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


