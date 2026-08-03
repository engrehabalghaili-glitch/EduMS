using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetMovementHistoryConfiguration : IEntityTypeConfiguration<AssetMovementHistory>
{
    public void Configure(EntityTypeBuilder<AssetMovementHistory> builder)
    {
        // Table Name
        builder.ToTable("asset_movement_history");

        // Property Configurations
        builder.Property(x => x.ActionType)
               .HasMaxLength(100);

        builder.Property(x => x.ActionDescription)
               .HasMaxLength(500);

        builder.Property(x => x.OldValueJson)
               .HasMaxLength(100);

        builder.Property(x => x.NewValueJson)
               .HasMaxLength(100);

        builder.Property(x => x.RelatedEntityType)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
