using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class FieldInventoryLogConfiguration : IEntityTypeConfiguration<FieldInventoryLog>
{
    public void Configure(EntityTypeBuilder<FieldInventoryLog> builder)
    {
        // Table Name
        builder.ToTable("field_inventory_log");

        // Property Configurations
        builder.Property(x => x.ScannedCode)
               .HasMaxLength(100);

        builder.Property(x => x.PhysicalLocationText)
               .HasMaxLength(100);

        builder.Property(x => x.ConditionNotes)
               .HasMaxLength(500);

        builder.Property(x => x.NotFoundNotes)
               .HasMaxLength(500);

        builder.Property(x => x.AssetPhotoUrl)
               .HasMaxLength(100);

        builder.Property(x => x.GpsLocation)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
