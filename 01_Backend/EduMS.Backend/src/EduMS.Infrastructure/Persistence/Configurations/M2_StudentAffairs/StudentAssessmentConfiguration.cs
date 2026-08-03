using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentAssessmentConfiguration : IEntityTypeConfiguration<StudentAssessment>
{
    public void Configure(EntityTypeBuilder<StudentAssessment> builder)
    {
        // Table Name
        builder.ToTable("student_assessment");

        // Property Configurations
        builder.Property(x => x.AssessmentTitle)
               .HasMaxLength(100);

        builder.Property(x => x.MaxScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.ObtainedScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.PassingScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.LetterCodeResult)
               .HasMaxLength(100);

        builder.Property(x => x.GradePointResult)
               .HasPrecision(18, 2);

        builder.Property(x => x.Remarks)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
