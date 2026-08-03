using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AttendanceDetailConfiguration : IEntityTypeConfiguration<AttendanceDetail>
{
    public void Configure(EntityTypeBuilder<AttendanceDetail> builder)
    {
        // Table Name
        builder.ToTable("attendance_detail");

        // Property Configurations
        builder.Property(x => x.AbsenceReason)
               .HasMaxLength(500);

        builder.Property(x => x.CheckInTime)
               .HasMaxLength(100);

        builder.Property(x => x.CheckOutTime)
               .HasMaxLength(100);

        builder.Property(x => x.ExcusalDocumentUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
