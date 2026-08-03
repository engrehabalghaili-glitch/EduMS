using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class FeeInvoiceConfiguration : IEntityTypeConfiguration<FeeInvoice>
{
    public void Configure(EntityTypeBuilder<FeeInvoice> builder)
    {
        // Table Name
        builder.ToTable("fee_invoice");

        // Property Configurations
        builder.Property(x => x.InvoiceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TotalAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaidAmount)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
