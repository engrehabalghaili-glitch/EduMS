using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ExamDistributionTimetableConfiguration : IEntityTypeConfiguration<ExamDistributionTimetable>
{
    public void Configure(EntityTypeBuilder<ExamDistributionTimetable> builder)
    {
        // Table Name
        builder.ToTable("exam_distribution_timetable");

        // Property Configurations
        builder.Property(x => x.StartTime)
               .HasMaxLength(100);

        builder.Property(x => x.EndTime)
               .HasMaxLength(100);

        builder.Property(x => x.ExamSessionNameAr)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
