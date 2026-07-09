using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_Finance.Configurations;

public class PayrollDetailConfiguration : IEntityTypeConfiguration<PayrollDetail>
{
    public void Configure(EntityTypeBuilder<PayrollDetail> builder)
    {
        builder.ToTable("PAYROLL_DETAIL");

        builder.HasKey(pd => pd.Id);
        builder.Property(pd => pd.Id).HasColumnName("PAYROLL_DETAIL_ID");

        builder.Property(pd => pd.PayrollRunId)
            .HasColumnName("PAYROLL_RUN_ID")
            .IsRequired();

        builder.Property(pd => pd.EmployeeId)
            .HasColumnName("EMPLOYEE_ID")
            .IsRequired();

        builder.Property(pd => pd.BaseSalary)
            .HasColumnName("BASE_SALARY")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(pd => pd.TotalAllowances)
            .HasColumnName("TOTAL_ALLOWANCES")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(pd => pd.TotalDeductions)
            .HasColumnName("TOTAL_DEDUCTIONS")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(pd => pd.NetSalary)
            .HasColumnName("NET_SALARY")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(pd => pd.Status)
            .HasColumnName("STATUS")
            .IsRequired();

        // Relationship mappings
        builder.HasOne(pd => pd.PayrollRun)
            .WithMany(p => p.PayrollDetails)
            .HasForeignKey(pd => pd.PayrollRunId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pd => pd.Employee)
            .WithMany()
            .HasForeignKey(pd => pd.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Audit Properties Configuration
        builder.Property(pd => pd.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(pd => pd.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(pd => pd.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(pd => pd.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(pd => pd.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(pd => pd.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(pd => pd.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(pd => pd.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(pd => pd.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(pd => pd.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
