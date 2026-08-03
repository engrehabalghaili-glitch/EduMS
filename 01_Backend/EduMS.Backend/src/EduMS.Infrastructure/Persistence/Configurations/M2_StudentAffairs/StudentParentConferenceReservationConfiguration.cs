using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentParentConferenceReservationConfiguration : IEntityTypeConfiguration<StudentParentConferenceReservation>
{
    public void Configure(EntityTypeBuilder<StudentParentConferenceReservation> builder)
    {
        // Table Name
        builder.ToTable("student_parent_conference_reservation");

        // Property Configurations
        builder.Property(x => x.DiscussionTopic)
               .HasMaxLength(100);

        builder.Property(x => x.ConferenceNotes)
               .HasMaxLength(500);

        builder.Property(x => x.MeetingRoomOrLink)
               .HasMaxLength(100);

        builder.Property(x => x.FollowUpActionItems)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
