using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeFinancialTransactionConfiguration : IEntityTypeConfiguration<EmployeeFinancialTransaction>
{
    public void Configure(EntityTypeBuilder<EmployeeFinancialTransaction> builder)
    {
        // Table Name
        builder.ToTable("employee_financial_transaction");

        // Property Configurations
        builder.Property(x => x.TransactionReferenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.Amount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        builder.Property(x => x.DescriptionEn)
               .HasMaxLength(500);

        builder.Property(x => x.Module5VoucherReference)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
