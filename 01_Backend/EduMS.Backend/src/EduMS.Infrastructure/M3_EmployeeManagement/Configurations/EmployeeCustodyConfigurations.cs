using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class EmployeeInventoryCustodyConfiguration : IEntityTypeConfiguration<EmployeeInventoryCustody>
{
    public void Configure(EntityTypeBuilder<EmployeeInventoryCustody> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.EstimatedValue).HasPrecision(18, 2);
        builder.Property(x => x.PenaltyAmount).HasPrecision(18, 2);

        builder.HasOne(x => x.Employee)
            .WithMany(e => e.InventoryCustodies)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class StaffCustodySummaryConfiguration : IEntityTypeConfiguration<StaffCustodySummary>
{
    public void Configure(EntityTypeBuilder<StaffCustodySummary> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TotalItemsCount).HasPrecision(18, 2);
        builder.Property(x => x.TotalEstimatedValue).HasPrecision(18, 2);

        builder.HasOne(x => x.Employee)
            .WithOne(e => e.CustodySummary)
            .HasForeignKey<StaffCustodySummary>(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
