using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyIncidentAssetImpactConfiguration : IEntityTypeConfiguration<EmergencyIncidentAssetImpact>
{
    public void Configure(EntityTypeBuilder<EmergencyIncidentAssetImpact> builder)
    {
        // Table Name
        builder.ToTable("emergency_incident_asset_impact");

        // Property Configurations
        builder.Property(x => x.EstimatedDamageValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.DamageDescription)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
