using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_Finance.Configurations;

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.ToTable("VENDOR");

        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id).HasColumnName("VENDOR_ID");

        builder.Property(v => v.VendorName)
            .HasColumnName("VENDOR_NAME")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(v => v.TaxNumber)
            .HasColumnName("TAX_NUMBER")
            .HasMaxLength(30);

        builder.Property(v => v.ContactName)
            .HasColumnName("CONTACT_NAME")
            .HasMaxLength(100);

        builder.Property(v => v.ContactEmail)
            .HasColumnName("CONTACT_EMAIL")
            .HasMaxLength(100);

        builder.Property(v => v.ContactPhone)
            .HasColumnName("CONTACT_PHONE")
            .HasMaxLength(30);

        builder.Property(v => v.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        // Audit Properties Configuration
        builder.Property(v => v.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(v => v.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(v => v.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(v => v.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(v => v.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(v => v.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(v => v.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(v => v.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(v => v.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(v => v.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
