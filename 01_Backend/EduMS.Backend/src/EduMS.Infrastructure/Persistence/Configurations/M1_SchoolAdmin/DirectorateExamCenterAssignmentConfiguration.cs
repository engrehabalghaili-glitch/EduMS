using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DirectorateExamCenterAssignmentConfiguration : IEntityTypeConfiguration<DirectorateExamCenterAssignment>
{
    public void Configure(EntityTypeBuilder<DirectorateExamCenterAssignment> builder)
    {
        // Table Name
        builder.ToTable("directorate_exam_center_assignment");

        // Property Configurations
        builder.Property(x => x.ExamCenterCode)
               .HasMaxLength(100);

        builder.Property(x => x.ExamSessionTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.AcademicYear)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
