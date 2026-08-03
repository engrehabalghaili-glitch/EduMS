using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentPsychologicalCounselingLogConfiguration : IEntityTypeConfiguration<StudentPsychologicalCounselingLog>
{
    public void Configure(EntityTypeBuilder<StudentPsychologicalCounselingLog> builder)
    {
        // Table Name
        builder.ToTable("student_psychological_counseling_log");

        // Property Configurations
        builder.Property(x => x.SessionNotes)
               .HasMaxLength(500);

        builder.Property(x => x.RecommendedIntervention)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
