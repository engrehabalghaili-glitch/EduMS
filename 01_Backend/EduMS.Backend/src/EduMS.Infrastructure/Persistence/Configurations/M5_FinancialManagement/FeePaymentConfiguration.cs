using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class FeePaymentConfiguration : IEntityTypeConfiguration<FeePayment>
{
    public void Configure(EntityTypeBuilder<FeePayment> builder)
    {
        // Table Name
        builder.ToTable("fee_payment");

        // Property Configurations
        builder.Property(x => x.PaymentNumber)
               .HasMaxLength(100);

        builder.Property(x => x.Amount)
               .HasPrecision(18, 2);

        builder.Property(x => x.AmountPaid)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.ExchangeRate)
               .HasPrecision(18, 2);

        builder.Property(x => x.ConvertedAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaymentType)
               .HasMaxLength(100);

        builder.Property(x => x.BankName)
               .HasMaxLength(100);

        builder.Property(x => x.BankTransactionId)
               .HasMaxLength(100);

        builder.Property(x => x.BankTransactionRef)
               .HasMaxLength(100);

        builder.Property(x => x.CheckNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ChequeNumber)
               .HasMaxLength(100);

        builder.Property(x => x.CheckBank)
               .HasMaxLength(100);

        builder.Property(x => x.CreditCardLast4)
               .HasMaxLength(100);

        builder.Property(x => x.CreditCardType)
               .HasMaxLength(100);

        builder.Property(x => x.WalletType)
               .HasMaxLength(100);

        builder.Property(x => x.PayerName)
               .HasMaxLength(100);

        builder.Property(x => x.PayerType)
               .HasMaxLength(100);

        builder.Property(x => x.PayerEmail)
               .HasMaxLength(100);

        builder.Property(x => x.ReceiptNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ReceiptDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.ReversalReason)
               .HasMaxLength(500);

        builder.Property(x => x.AllocatedInvoicesJson)
               .HasMaxLength(100);

        builder.Property(x => x.AllocatedItemsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
