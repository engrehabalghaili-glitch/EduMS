using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class AcademicLockPeriodConfiguration : IEntityTypeConfiguration<AcademicLockPeriod>
{
    public void Configure(EntityTypeBuilder<AcademicLockPeriod> builder)
    {
        builder.ToTable("ACADEMIC_LOCK_PERIOD");

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasColumnName("LOCK_PERIOD_ID");

        builder.Property(l => l.OfficeId)
            .HasColumnName("OFFICE_ID")
            .IsRequired();

        builder.Property(l => l.SchoolId)
            .HasColumnName("SCHOOL_ID")
            .IsRequired();

        builder.Property(l => l.PeriodName)
            .HasColumnName("PERIOD_NAME")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(l => l.StartDate)
            .HasColumnName("START_DATE")
            .IsRequired();

        builder.Property(l => l.EndDate)
            .HasColumnName("END_DATE")
            .IsRequired();

        builder.Property(l => l.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        builder.Property(l => l.LockGradeRosters)
            .HasColumnName("LOCK_GRADE_ROSTERS")
            .IsRequired();

        builder.Property(l => l.LockEnrollmentSnapshots)
            .HasColumnName("LOCK_ENROLLMENT_SNAPSHOTS")
            .IsRequired();

        builder.Property(l => l.LockPeriodStatisticalReports)
            .HasColumnName("LOCK_PERIOD_STATS_REPORTS")
            .IsRequired();

        // Audit Properties Configuration
        builder.Property(l => l.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(l => l.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(l => l.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(l => l.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(l => l.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(l => l.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(l => l.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(l => l.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(l => l.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(l => l.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
