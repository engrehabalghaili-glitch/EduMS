using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class TeacherScheduleConfiguration : IEntityTypeConfiguration<TeacherSchedule>
{
    public void Configure(EntityTypeBuilder<TeacherSchedule> builder)
    {
        // Table Name
        builder.ToTable("teacher_schedule");

        // Property Configurations
        builder.Property(x => x.DayOfWeek)
               .HasMaxLength(100);

        builder.Property(x => x.SubstituteReason)
               .HasMaxLength(500);

        builder.Property(x => x.CancellationReason)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
