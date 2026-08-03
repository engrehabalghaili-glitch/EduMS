using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class MaintenanceSparePartConfiguration : IEntityTypeConfiguration<MaintenanceSparePart>
{
    public void Configure(EntityTypeBuilder<MaintenanceSparePart> builder)
    {
        // Table Name
        builder.ToTable("maintenance_spare_part");

        // Property Configurations
        builder.Property(x => x.PartCode)
               .HasMaxLength(100);

        builder.Property(x => x.PartNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.PartNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.PartCategory)
               .HasMaxLength(100);

        builder.Property(x => x.Manufacturer)
               .HasMaxLength(100);

        builder.Property(x => x.CompatibleAssetsJson)
               .HasMaxLength(100);

        builder.Property(x => x.UnitOfMeasure)
               .HasMaxLength(100);

        builder.Property(x => x.UnitCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.SupplierName)
               .HasMaxLength(100);

        builder.Property(x => x.LocationInWarehouse)
               .HasMaxLength(100);

        builder.Property(x => x.TotalConsumed)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
