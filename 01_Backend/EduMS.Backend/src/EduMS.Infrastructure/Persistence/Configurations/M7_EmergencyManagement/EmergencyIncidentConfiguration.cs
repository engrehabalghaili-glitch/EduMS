using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyIncidentConfiguration : IEntityTypeConfiguration<EmergencyIncident>
{
    public void Configure(EntityTypeBuilder<EmergencyIncident> builder)
    {
        // Table Name
        builder.ToTable("emergency_incident");

        // Property Configurations
        builder.Property(x => x.IncidentNumber)
               .HasMaxLength(100);

        builder.Property(x => x.IncidentType)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.LocationText)
               .HasMaxLength(100);

        builder.Property(x => x.PropertyDamage)
               .HasPrecision(18, 2);

        builder.Property(x => x.PropertyDamageDescription)
               .HasMaxLength(500);

        builder.Property(x => x.EmergencyResponseActions)
               .HasMaxLength(100);

        builder.Property(x => x.ExternalAgenciesJson)
               .HasMaxLength(100);

        builder.Property(x => x.ClosureNotes)
               .HasMaxLength(500);

        builder.Property(x => x.InvestigationReportUrl)
               .HasMaxLength(100);

        builder.Property(x => x.LessonsLearned)
               .HasMaxLength(100);

        builder.Property(x => x.Recommendations)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
