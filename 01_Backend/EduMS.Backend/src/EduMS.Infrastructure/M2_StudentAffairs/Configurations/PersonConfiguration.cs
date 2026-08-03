using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M2_Student.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("PERSON");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("PERSON_ID");

        builder.Property(p => p.FullNameAr)
            .HasColumnName("FULL_NAME_AR")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.FullNameEn)
            .HasColumnName("FULL_NAME_EN")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.NationalId)
            .HasColumnName("NATIONAL_ID")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(p => p.NationalId).IsUnique();

        builder.Property(p => p.Gender)
            .HasColumnName("GENDER")
            .IsRequired();

        builder.Property(p => p.ContactNumber)
            .HasColumnName("CONTACT_NUMBER")
            .HasMaxLength(30);

        builder.Property(p => p.MedicalInfo)
            .HasColumnName("MEDICAL_INFO");

        // Audit Properties Configuration
        builder.Property(p => p.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(p => p.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(p => p.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(p => p.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(p => p.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(p => p.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(p => p.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(p => p.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(p => p.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
