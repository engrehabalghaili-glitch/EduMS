using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentAssignmentSubmissionConfiguration : IEntityTypeConfiguration<StudentAssignmentSubmission>
{
    public void Configure(EntityTypeBuilder<StudentAssignmentSubmission> builder)
    {
        // Table Name
        builder.ToTable("student_assignment_submission");

        // Property Configurations
        builder.Property(x => x.AssignmentTitle)
               .HasMaxLength(100);

        builder.Property(x => x.ScoreObtained)
               .HasPrecision(18, 2);

        builder.Property(x => x.TeacherFeedback)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentFileUrl)
               .HasMaxLength(100);

        builder.Property(x => x.MaxPossibleScore)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
