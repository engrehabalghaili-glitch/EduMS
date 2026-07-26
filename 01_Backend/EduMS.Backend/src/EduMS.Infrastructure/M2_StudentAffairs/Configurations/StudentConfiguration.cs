using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M2_Student.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("STUDENT");

        builder.Property(s => s.EnrollmentNumber)
            .HasColumnName("ENROLLMENT_NUMBER")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(s => s.EnrollmentDate)
            .HasColumnName("ENROLLMENT_DATE")
            .IsRequired();

        builder.Property(s => s.SchoolId)
            .HasColumnName("SCHOOL_ID");

        builder.Property(s => s.GuardianId)
            .HasColumnName("GUARDIAN_ID");

        builder.Property(s => s.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();
    }
}
