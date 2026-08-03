using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeTrainingConfiguration : IEntityTypeConfiguration<EmployeeTraining>
{
    public void Configure(EntityTypeBuilder<EmployeeTraining> builder)
    {
        // Table Name
        builder.ToTable("employee_training");

        // Property Configurations
        builder.Property(x => x.CourseName)
               .HasMaxLength(100);

        builder.Property(x => x.CourseCode)
               .HasMaxLength(100);

        builder.Property(x => x.ProviderName)
               .HasMaxLength(100);

        builder.Property(x => x.TrainingLocation)
               .HasMaxLength(100);

        builder.Property(x => x.TrainingCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.FundingSource)
               .HasMaxLength(100);

        builder.Property(x => x.Score)
               .HasPrecision(18, 2);

        builder.Property(x => x.GradeLevel)
               .HasMaxLength(100);

        builder.Property(x => x.CertificateUrl)
               .HasMaxLength(100);

        builder.Property(x => x.TrainingOutcomesSummary)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
