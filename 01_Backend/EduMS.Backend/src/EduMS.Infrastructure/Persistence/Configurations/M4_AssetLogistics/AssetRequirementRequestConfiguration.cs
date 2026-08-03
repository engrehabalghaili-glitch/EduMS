using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetRequirementRequestConfiguration : IEntityTypeConfiguration<AssetRequirementRequest>
{
    public void Configure(EntityTypeBuilder<AssetRequirementRequest> builder)
    {
        // Table Name
        builder.ToTable("asset_requirement_request");

        // Property Configurations
        builder.Property(x => x.RequestNumber)
               .HasMaxLength(100);

        builder.Property(x => x.AssetTypeDescription)
               .HasMaxLength(500);

        builder.Property(x => x.EstimatedUnitCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.EstimatedTotalCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.UrgencyReason)
               .HasMaxLength(500);

        builder.Property(x => x.Justification)
               .HasMaxLength(100);

        builder.Property(x => x.InitialSpecsText)
               .HasMaxLength(100);

        builder.Property(x => x.ReplacementReason)
               .HasMaxLength(500);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
