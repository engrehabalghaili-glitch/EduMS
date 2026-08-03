using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.ToTable("SCHOOL");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("SCHOOL_ID");

        builder.Property(s => s.SchoolNameAr)
            .HasColumnName("SCHOOL_NAME_AR")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(s => s.SchoolNameEn)
            .HasColumnName("SCHOOL_NAME_EN")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(s => s.SchoolCode)
            .HasColumnName("SCHOOL_CODE")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(s => s.SchoolCode).IsUnique();

        builder.Property(s => s.Directorate)
            .HasColumnName("DIRECTORATE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.Governorate)
            .HasColumnName("GOVERNORATE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        // Audit Properties Configuration
        builder.Property(s => s.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(s => s.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(s => s.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(s => s.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(s => s.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(s => s.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(s => s.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(s => s.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(s => s.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(s => s.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
