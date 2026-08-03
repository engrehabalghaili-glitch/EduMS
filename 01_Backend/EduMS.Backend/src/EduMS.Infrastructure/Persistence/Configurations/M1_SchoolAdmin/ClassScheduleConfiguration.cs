using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ClassScheduleConfiguration : IEntityTypeConfiguration<ClassSchedule>
{
    public void Configure(EntityTypeBuilder<ClassSchedule> builder)
    {
        // Table Name
        builder.ToTable("class_schedule");

        // Property Configurations
        builder.Property(x => x.RoomCode)
               .HasMaxLength(100);

        builder.Property(x => x.StartTime)
               .HasMaxLength(100);

        builder.Property(x => x.EndTime)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
