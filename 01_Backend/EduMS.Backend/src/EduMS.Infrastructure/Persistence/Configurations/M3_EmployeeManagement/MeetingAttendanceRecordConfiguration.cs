using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class MeetingAttendanceRecordConfiguration : IEntityTypeConfiguration<MeetingAttendanceRecord>
{
    public void Configure(EntityTypeBuilder<MeetingAttendanceRecord> builder)
    {
        // Table Name
        builder.ToTable("meeting_attendance_record");

        // Property Configurations
        builder.Property(x => x.AttendanceMethod)
               .HasMaxLength(100);

        builder.Property(x => x.AbsenceReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
