using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_Finance.Configurations;

public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
{
    public void Configure(EntityTypeBuilder<JournalEntry> builder)
    {
        builder.ToTable("JOURNAL_ENTRY");

        builder.HasKey(j => j.Id);
        builder.Property(j => j.Id).HasColumnName("JOURNAL_ENTRY_ID");

        builder.Property(j => j.EntryNumber)
            .HasColumnName("ENTRY_NUMBER")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(j => j.EntryNumber).IsUnique();

        builder.Property(j => j.EntryDate)
            .HasColumnName("ENTRY_DATE")
            .IsRequired();

        builder.Property(j => j.Description)
            .HasColumnName("DESCRIPTION")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(j => j.Status)
            .HasColumnName("STATUS")
            .IsRequired();

        // Audit Properties Configuration
        builder.Property(j => j.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(j => j.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(j => j.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(j => j.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(j => j.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(j => j.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(j => j.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(j => j.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(j => j.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(j => j.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
