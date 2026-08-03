using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_Finance.Configurations;

public class PaymentVoucherConfiguration : IEntityTypeConfiguration<PaymentVoucher>
{
    public void Configure(EntityTypeBuilder<PaymentVoucher> builder)
    {
        builder.ToTable("PAYMENT_VOUCHER");

        builder.HasKey(pv => pv.Id);
        builder.Property(pv => pv.Id).HasColumnName("PAYMENT_VOUCHER_ID");

        builder.Property(pv => pv.VoucherNumber)
            .HasColumnName("VOUCHER_NUMBER")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(pv => pv.VoucherNumber).IsUnique();

        builder.Property(pv => pv.VoucherDate)
            .HasColumnName("VOUCHER_DATE")
            .IsRequired();

        builder.Property(pv => pv.TotalAmount)
            .HasColumnName("TOTAL_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(pv => pv.PaymentMethod)
            .HasColumnName("PAYMENT_METHOD")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(pv => pv.Description)
            .HasColumnName("DESCRIPTION")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(pv => pv.AccountId)
            .HasColumnName("ACCOUNT_ID");

        // Relationship mapping
        builder.HasOne(pv => pv.Account)
            .WithMany()
            .HasForeignKey(pv => pv.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        // Audit Properties Configuration
        builder.Property(pv => pv.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(pv => pv.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(pv => pv.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(pv => pv.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(pv => pv.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(pv => pv.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(pv => pv.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(pv => pv.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(pv => pv.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(pv => pv.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
