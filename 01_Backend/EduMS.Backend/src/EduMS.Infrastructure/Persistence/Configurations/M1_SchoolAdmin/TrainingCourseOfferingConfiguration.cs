using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class TrainingCourseOfferingConfiguration : IEntityTypeConfiguration<TrainingCourseOffering>
{
    public void Configure(EntityTypeBuilder<TrainingCourseOffering> builder)
    {
        // Table Name
        builder.ToTable("training_course_offering");

        // Property Configurations
        builder.Property(x => x.CourseCode)
               .HasMaxLength(100);

        builder.Property(x => x.CourseTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.TrainerName)
               .HasMaxLength(100);

        builder.Property(x => x.CostPerParticipant)
               .HasPrecision(18, 2);

        builder.Property(x => x.CourseTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.TrainingLocation)
               .HasMaxLength(100);

        builder.Property(x => x.TargetSpecialization)
               .HasMaxLength(100);

        builder.Property(x => x.CertificateTemplateUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
