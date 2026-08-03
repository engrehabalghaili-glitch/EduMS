using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PayrollDetailConfiguration : IEntityTypeConfiguration<PayrollDetail>
{
    public void Configure(EntityTypeBuilder<PayrollDetail> builder)
    {
        // Table Name
        builder.ToTable("payroll_detail");

        // Property Configurations
        builder.Property(x => x.BaseSalary)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalAllowances)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDeductions)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetSalary)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
