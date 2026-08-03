using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeePayrollFinancialContractConfiguration : IEntityTypeConfiguration<EmployeePayrollFinancialContract>
{
    public void Configure(EntityTypeBuilder<EmployeePayrollFinancialContract> builder)
    {
        // Table Name
        builder.ToTable("employee_payroll_financial_contract");

        // Property Configurations
        builder.Property(x => x.FinancialTransactionReferenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.CostCenterCode)
               .HasMaxLength(100);

        builder.Property(x => x.BudgetLineCode)
               .HasMaxLength(100);

        builder.Property(x => x.TotalGrossAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDeductionsAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetDisbursementAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.BankTransferReference)
               .HasMaxLength(100);

        builder.Property(x => x.FinancialAuditNotes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
