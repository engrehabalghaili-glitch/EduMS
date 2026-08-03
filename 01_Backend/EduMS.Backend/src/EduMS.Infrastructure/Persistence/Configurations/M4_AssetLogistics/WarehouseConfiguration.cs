using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        // Table Name
        builder.ToTable("warehouse");

        // Property Configurations
        builder.Property(x => x.WarehouseName)
               .HasMaxLength(100);

        builder.Property(x => x.OwnerType)
               .HasMaxLength(100);

        builder.Property(x => x.LocationAddress)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
