using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PaymentVoucherConfiguration : IEntityTypeConfiguration<PaymentVoucher>
{
    public void Configure(EntityTypeBuilder<PaymentVoucher> builder)
    {
        // Table Name
        builder.ToTable("payment_voucher");

        // Property Configurations
        builder.Property(x => x.VoucherNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TotalAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaymentMethod)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
