using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeTrainingCourseLinkConfiguration : IEntityTypeConfiguration<EmployeeTrainingCourseLink>
{
    public void Configure(EntityTypeBuilder<EmployeeTrainingCourseLink> builder)
    {
        // Table Name
        builder.ToTable("employee_training_course_link");

        // Property Configurations
        builder.Property(x => x.TrainingFeeAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.FundingSource)
               .HasMaxLength(100);

        builder.Property(x => x.CertificateUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
