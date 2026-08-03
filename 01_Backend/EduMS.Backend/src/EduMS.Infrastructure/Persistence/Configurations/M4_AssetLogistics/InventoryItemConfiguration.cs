using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        // Table Name
        builder.ToTable("inventory_item");

        // Property Configurations
        builder.Property(x => x.ItemName)
               .HasMaxLength(100);

        builder.Property(x => x.ItemCode)
               .HasMaxLength(100);

        builder.Property(x => x.UnitOfMeasure)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
