using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
{
    public void Configure(EntityTypeBuilder<InvoiceItem> builder)
    {
        // Table Name
        builder.ToTable("invoice_item");

        // Property Configurations
        builder.Property(x => x.ItemCode)
               .HasMaxLength(100);

        builder.Property(x => x.ItemDescription)
               .HasMaxLength(500);

        builder.Property(x => x.UnitPrice)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalPrice)
               .HasPrecision(18, 2);

        builder.Property(x => x.DiscountPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.DiscountAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PriceAfterDiscount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TaxPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.TaxAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaidAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.RemainingAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaymentMethod)
               .HasMaxLength(100);

        builder.Property(x => x.LateFeeAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.WaiverReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
