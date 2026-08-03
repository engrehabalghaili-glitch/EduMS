using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class FeeInstallmentConfiguration : IEntityTypeConfiguration<FeeInstallment>
{
    public void Configure(EntityTypeBuilder<FeeInstallment> builder)
    {
        // Table Name
        builder.ToTable("fee_installment");

        // Property Configurations
        builder.Property(x => x.InstallmentAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.PaidAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.RemainingAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaymentMethod)
               .HasMaxLength(100);

        builder.Property(x => x.PaymentReference)
               .HasMaxLength(100);

        builder.Property(x => x.InstallmentType)
               .HasMaxLength(100);

        builder.Property(x => x.LateFeePercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.LateFeeAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.LateFeePaymentReference)
               .HasMaxLength(100);

        builder.Property(x => x.RescheduledReason)
               .HasMaxLength(500);

        builder.Property(x => x.WaiverReason)
               .HasMaxLength(500);

        builder.Property(x => x.WaiverApprovalDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
