using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DirectorateStatisticsSnapshotConfiguration : IEntityTypeConfiguration<DirectorateStatisticsSnapshot>
{
    public void Configure(EntityTypeBuilder<DirectorateStatisticsSnapshot> builder)
    {
        // Physical table — NOT a view. Stores official directorate-level snapshots.
        builder.ToTable("DIRECTORATE_STAT_SNAPSHOT");

        builder.Property(x => x.DropoutRate).HasPrecision(5, 2);
        builder.Property(x => x.AvgPassRate).HasPrecision(5, 2);
        builder.Property(x => x.AvgAttendanceRate).HasPrecision(5, 2);

        builder.Property(x => x.PerSchoolBreakdownJson).HasColumnType("CLOB");
        builder.Property(x => x.FinancialSummaryJson).HasColumnType("CLOB");
        builder.Property(x => x.StaffShortageAnalysisJson).HasColumnType("CLOB");

        builder.Property(x => x.Notes).HasMaxLength(1000);

        // Unique: one snapshot per directorate per period
        builder.HasIndex(x => new { x.DirectorateId, x.AcademicYearId, x.PeriodType, x.PeriodValue })
               .IsUnique()
               .HasDatabaseName("UX_DIR_STAT_SNAP_PERIOD");

        builder.HasOne(x => x.Directorate)
               .WithMany()
               .HasForeignKey(x => x.DirectorateId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
