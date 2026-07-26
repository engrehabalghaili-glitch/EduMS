using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class EmployeePayrollFinancialContractConfiguration : IEntityTypeConfiguration<EmployeePayrollFinancialContract>
{
    public void Configure(EntityTypeBuilder<EmployeePayrollFinancialContract> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalGrossAmount).HasPrecision(18, 2);
        builder.Property(x => x.TotalDeductionsAmount).HasPrecision(18, 2);
        builder.Property(x => x.NetDisbursementAmount).HasPrecision(18, 2);

        builder.HasOne(x => x.Employee)
            .WithMany(e => e.PayrollFinancialContracts)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FinancialAuditorEmployee)
            .WithMany()
            .HasForeignKey(x => x.FinancialAuditorEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
