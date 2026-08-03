using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        // Table Name
        builder.ToTable("student");

        // Property Configurations
        builder.Property(x => x.EnrollmentNumber)
               .HasMaxLength(100);

        builder.Property(x => x.PreviousSchoolName)
               .HasMaxLength(100);

        builder.Property(x => x.CurrentAcademicYear)
               .HasMaxLength(100);

        builder.Property(x => x.SpecialEducationNeeds)
               .HasMaxLength(100);

        builder.Property(x => x.BusStopLocationDescription)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
