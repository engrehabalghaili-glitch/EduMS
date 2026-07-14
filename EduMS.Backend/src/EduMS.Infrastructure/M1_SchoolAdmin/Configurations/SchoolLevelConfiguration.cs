using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class SchoolLevelConfiguration : IEntityTypeConfiguration<SchoolLevel>
{
    public void Configure(EntityTypeBuilder<SchoolLevel> builder)
    {
        builder.ToTable("SCHOOL_LEVEL");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.SchoolId)
            .HasColumnName("SCHOOL_ID")
            .IsRequired();

        builder.Property(e => e.LevelNameAr)
            .HasColumnName("LEVEL_NAME_AR")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.LevelNameEn)
            .HasColumnName("LEVEL_NAME_EN")
            .HasMaxLength(150);

        builder.Property(e => e.LevelOrder)
            .HasColumnName("LEVEL_ORDER")
            .IsRequired();

        builder.Property(e => e.StartGrade)
            .HasColumnName("START_GRADE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.EndGrade)
            .HasColumnName("END_GRADE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.AcademicTrack)
            .HasColumnName("ACADEMIC_TRACK")
            .HasMaxLength(100);

        builder.Property(e => e.MinAgeYears)
            .HasColumnName("MIN_AGE_YEARS")
            .IsRequired();

        builder.Property(e => e.MaxAgeYears)
            .HasColumnName("MAX_AGE_YEARS")
            .IsRequired();

        builder.Property(e => e.DefaultShiftId)
            .HasColumnName("DEFAULT_SHIFT_ID");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES")
            .HasMaxLength(500);

        // Audit Properties Configuration
        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");

        builder.HasOne(e => e.School)
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
