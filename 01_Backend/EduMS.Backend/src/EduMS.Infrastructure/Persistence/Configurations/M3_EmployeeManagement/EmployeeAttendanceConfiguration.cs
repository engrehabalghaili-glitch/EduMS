using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeAttendanceConfiguration : IEntityTypeConfiguration<EmployeeAttendance>
{
    public void Configure(EntityTypeBuilder<EmployeeAttendance> builder)
    {
        // Table Name
        builder.ToTable("employee_attendance");

        // Property Configurations
        builder.Property(x => x.DayOfWeek)
               .HasMaxLength(100);

        builder.Property(x => x.CheckInLocationGps)
               .HasMaxLength(100);

        builder.Property(x => x.AttendanceStatus)
               .HasMaxLength(100);

        builder.Property(x => x.TotalWorkHours)
               .HasPrecision(18, 2);

        builder.Property(x => x.ExcuseDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.OverrideReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
