using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ExternalParticipationConfiguration : IEntityTypeConfiguration<ExternalParticipation>
{
    public void Configure(EntityTypeBuilder<ExternalParticipation> builder)
    {
        // Table Name
        builder.ToTable("external_participation");

        // Property Configurations
        builder.Property(x => x.ParticipationNumber)
               .HasMaxLength(100);

        builder.Property(x => x.EventName)
               .HasMaxLength(100);

        builder.Property(x => x.EventType)
               .HasMaxLength(100);

        builder.Property(x => x.Organizer)
               .HasMaxLength(100);

        builder.Property(x => x.OrganizerType)
               .HasMaxLength(100);

        builder.Property(x => x.Location)
               .HasMaxLength(100);

        builder.Property(x => x.Results)
               .HasMaxLength(100);

        builder.Property(x => x.Ranking)
               .HasMaxLength(100);

        builder.Property(x => x.ParticipantsJson)
               .HasMaxLength(100);

        builder.Property(x => x.ExpensesJson)
               .HasMaxLength(100);

        builder.Property(x => x.FundingSource)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.LessonsLearned)
               .HasMaxLength(100);

        builder.Property(x => x.Recommendations)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
