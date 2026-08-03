using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyClosureConfiguration : IEntityTypeConfiguration<EmergencyClosure>
{
    public void Configure(EntityTypeBuilder<EmergencyClosure> builder)
    {
        // Table Name
        builder.ToTable("emergency_closure");

        // Property Configurations
        builder.Property(x => x.ClosureNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ClosureReason)
               .HasMaxLength(500);

        builder.Property(x => x.DecisionAuthority)
               .HasMaxLength(100);

        builder.Property(x => x.AuthorityDecisionNumber)
               .HasMaxLength(100);

        builder.Property(x => x.AlternativeEducationType)
               .HasMaxLength(100);

        builder.Property(x => x.AltEducationPlatform)
               .HasMaxLength(100);

        builder.Property(x => x.AltEducationDetails)
               .HasMaxLength(100);

        builder.Property(x => x.ParentNotificationMethod)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
