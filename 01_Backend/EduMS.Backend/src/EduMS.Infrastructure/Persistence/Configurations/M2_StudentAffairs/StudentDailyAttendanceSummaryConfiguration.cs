using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentDailyAttendanceSummaryConfiguration : IEntityTypeConfiguration<StudentDailyAttendanceSummary>
{
    public void Configure(EntityTypeBuilder<StudentDailyAttendanceSummary> builder)
    {
        // Table Name
        builder.ToTable("student_daily_attendance_summary");

        // Property Configurations
        builder.Property(x => x.AcademicYear)
               .HasMaxLength(100);

        builder.Property(x => x.TotalAbsencePercentage)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
