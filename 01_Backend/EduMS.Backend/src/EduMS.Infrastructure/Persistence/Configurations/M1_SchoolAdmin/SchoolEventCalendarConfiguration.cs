using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolEventCalendarConfiguration : IEntityTypeConfiguration<SchoolEventCalendar>
{
    public void Configure(EntityTypeBuilder<SchoolEventCalendar> builder)
    {
        // Table Name
        builder.ToTable("school_event_calendar");

        // Property Configurations
        builder.Property(x => x.EventTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.EventTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.LocationDetails)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
