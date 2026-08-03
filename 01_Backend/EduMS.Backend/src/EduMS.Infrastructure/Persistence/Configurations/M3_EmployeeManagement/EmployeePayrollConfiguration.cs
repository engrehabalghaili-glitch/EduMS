using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeePayrollConfiguration : IEntityTypeConfiguration<EmployeePayroll>
{
    public void Configure(EntityTypeBuilder<EmployeePayroll> builder)
    {
        // Table Name
        builder.ToTable("employee_payroll");

        // Property Configurations
        builder.Property(x => x.BasicSalary)
               .HasPrecision(18, 2);

        builder.Property(x => x.HousingAllowance)
               .HasPrecision(18, 2);

        builder.Property(x => x.TransportAllowance)
               .HasPrecision(18, 2);

        builder.Property(x => x.OtherAllowances)
               .HasPrecision(18, 2);

        builder.Property(x => x.OvertimePay)
               .HasPrecision(18, 2);

        builder.Property(x => x.GrossTotal)
               .HasPrecision(18, 2);

        builder.Property(x => x.DeductionAbsence)
               .HasPrecision(18, 2);

        builder.Property(x => x.DeductionInsurance)
               .HasPrecision(18, 2);

        builder.Property(x => x.DeductionOther)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetSalary)
               .HasPrecision(18, 2);

        builder.Property(x => x.PaymentMethod)
               .HasMaxLength(100);

        builder.Property(x => x.BankTransactionRef)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
