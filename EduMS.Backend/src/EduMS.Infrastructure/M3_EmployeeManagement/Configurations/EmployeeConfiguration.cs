using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M3_Employee.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("EMPLOYEE");

        builder.Property(e => e.EmployeeNumber)
            .HasColumnName("EMPLOYEE_NUMBER")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.JobTitle)
            .HasColumnName("JOB_TITLE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.BaseSalary)
            .HasColumnName("BASE_SALARY")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.HireDate)
            .HasColumnName("HIRE_DATE")
            .IsRequired();

        builder.Property(e => e.SchoolId)
            .HasColumnName("SCHOOL_ID");
    }
}
