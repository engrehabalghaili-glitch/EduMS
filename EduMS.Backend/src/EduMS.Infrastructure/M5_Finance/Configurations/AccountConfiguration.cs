using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_Finance.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("ACCOUNT");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("ACCOUNT_ID");

        builder.Property(a => a.AccountCode)
            .HasColumnName("ACCOUNT_CODE")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(a => a.AccountCode).IsUnique();

        builder.Property(a => a.AccountNameAr)
            .HasColumnName("ACCOUNT_NAME_AR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.AccountNameEn)
            .HasColumnName("ACCOUNT_NAME_EN")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.ParentAccountId)
            .HasColumnName("PARENT_ACCOUNT_ID");

        builder.Property(a => a.AccountType)
            .HasColumnName("ACCOUNT_TYPE")
            .IsRequired();

        builder.Property(a => a.LevelNumber)
            .HasColumnName("LEVEL_NUMBER")
            .IsRequired();

        builder.Property(a => a.CurrentBalance)
            .HasColumnName("CURRENT_BALANCE")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(a => a.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        // Self-referencing configuration
        builder.HasOne(a => a.ParentAccount)
            .WithMany(a => a.ChildAccounts)
            .HasForeignKey(a => a.ParentAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        // Audit Properties Configuration
        builder.Property(a => a.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(a => a.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(a => a.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(a => a.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(a => a.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(a => a.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(a => a.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(a => a.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(a => a.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(a => a.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
