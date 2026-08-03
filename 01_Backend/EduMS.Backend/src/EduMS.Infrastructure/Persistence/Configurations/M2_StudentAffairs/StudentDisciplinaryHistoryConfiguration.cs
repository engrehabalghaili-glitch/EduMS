using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentDisciplinaryHistoryConfiguration : IEntityTypeConfiguration<StudentDisciplinaryHistory>
{
    public void Configure(EntityTypeBuilder<StudentDisciplinaryHistory> builder)
    {
        // Table Name
        builder.ToTable("student_disciplinary_history");

        // Property Configurations
        builder.Property(x => x.DisciplinaryActionCode)
               .HasMaxLength(100);

        builder.Property(x => x.ActionTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.ActionTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.AppealNotes)
               .HasMaxLength(500);

        builder.Property(x => x.ReinstatementCondition)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
