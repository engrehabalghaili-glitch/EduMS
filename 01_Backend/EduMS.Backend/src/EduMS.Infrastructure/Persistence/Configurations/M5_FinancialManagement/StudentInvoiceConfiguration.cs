using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentInvoiceConfiguration : IEntityTypeConfiguration<StudentInvoice>
{
    public void Configure(EntityTypeBuilder<StudentInvoice> builder)
    {
        // Table Name
        builder.ToTable("student_invoice");

        // Property Configurations
        builder.Property(x => x.InvoiceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TotalAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.SubtotalAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.DiscountAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TaxAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TaxRate)
               .HasPrecision(18, 2);

        builder.Property(x => x.TaxRegistrationNumber)
               .HasMaxLength(100);

        builder.Property(x => x.NetAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaidAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.RemainingAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.BalanceDue)
               .HasPrecision(18, 2);

        builder.Property(x => x.InvoiceType)
               .HasMaxLength(100);

        builder.Property(x => x.InvoiceCategory)
               .HasMaxLength(100);

        builder.Property(x => x.PaymentMethod)
               .HasMaxLength(100);

        builder.Property(x => x.LateFeePercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.LateFeeAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
