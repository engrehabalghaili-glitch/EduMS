using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyHostingWarehouseLinkConfiguration : IEntityTypeConfiguration<EmergencyHostingWarehouseLink>
{
    public void Configure(EntityTypeBuilder<EmergencyHostingWarehouseLink> builder)
    {
        // Table Name
        builder.ToTable("emergency_hosting_warehouse_link");

        // Property Configurations
        builder.Property(x => x.SuppliesUsedJson)
               .HasMaxLength(100);

        builder.Property(x => x.TotalSupplyValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
