using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class EmployeeFinancialTransactionConfiguration : IEntityTypeConfiguration<EmployeeFinancialTransaction>
{
    public void Configure(EntityTypeBuilder<EmployeeFinancialTransaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount).HasPrecision(18, 2);

        builder.HasOne(x => x.Employee)
            .WithMany(e => e.FinancialTransactions)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApprovedByEmployee)
            .WithMany()
            .HasForeignKey(x => x.ApprovedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
