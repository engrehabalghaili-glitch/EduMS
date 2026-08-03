using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeMeetingConfiguration : IEntityTypeConfiguration<EmployeeMeeting>
{
    public void Configure(EntityTypeBuilder<EmployeeMeeting> builder)
    {
        // Table Name
        builder.ToTable("employee_meeting");

        // Property Configurations
        builder.Property(x => x.MeetingTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.MeetingLocation)
               .HasMaxLength(100);

        builder.Property(x => x.AgendaJson)
               .HasMaxLength(100);

        builder.Property(x => x.MinutesText)
               .HasMaxLength(100);

        builder.Property(x => x.DecisionsJson)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
