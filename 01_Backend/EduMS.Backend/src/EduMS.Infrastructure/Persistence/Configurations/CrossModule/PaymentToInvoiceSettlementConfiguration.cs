using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PaymentToInvoiceSettlementConfiguration : IEntityTypeConfiguration<PaymentToInvoiceSettlement>
{
    public void Configure(EntityTypeBuilder<PaymentToInvoiceSettlement> builder)
    {
        // Table Name
        builder.ToTable("payment_to_invoice_settlement");

        // Property Configurations
        builder.Property(x => x.AllocatedAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
