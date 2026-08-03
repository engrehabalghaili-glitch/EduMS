using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        // Table Name
        builder.ToTable("purchase_order");

        // Property Configurations
        builder.Property(x => x.PoNumber)
               .HasMaxLength(100);

        builder.Property(x => x.SupplierName)
               .HasMaxLength(100);

        builder.Property(x => x.SupplierContact)
               .HasMaxLength(100);

        builder.Property(x => x.TotalAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TaxAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaymentTerms)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
