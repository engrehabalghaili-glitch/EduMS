using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("EMPLOYEE");

        builder.Property(e => e.EmployeeCode)
            .HasColumnName("EMPLOYEE_CODE")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.JobTitle)
            .HasColumnName("JOB_TITLE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ContractType)
            .HasColumnName("CONTRACT_TYPE")
            .IsRequired();

        builder.Property(e => e.HireDate)
            .HasColumnName("HIRE_DATE")
            .IsRequired();

        builder.Property(e => e.SchoolId)
            .HasColumnName("SCHOOL_ID");

        builder.HasOne(e => e.School)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Directorate)
            .WithMany()
            .HasForeignKey(e => e.DirectorateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
