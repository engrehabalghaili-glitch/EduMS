using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeInventoryCustodyConfiguration : IEntityTypeConfiguration<EmployeeInventoryCustody>
{
    public void Configure(EntityTypeBuilder<EmployeeInventoryCustody> builder)
    {
        // Table Name
        builder.ToTable("employee_inventory_custody");

        // Property Configurations
        builder.Property(x => x.ItemType)
               .HasMaxLength(100);

        builder.Property(x => x.ItemNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ItemBrand)
               .HasMaxLength(100);

        builder.Property(x => x.ItemModel)
               .HasMaxLength(100);

        builder.Property(x => x.ItemSerialNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ItemCode)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.HandoverNotes)
               .HasMaxLength(500);

        builder.Property(x => x.ReceiptSignatureUrl)
               .HasMaxLength(100);

        builder.Property(x => x.ReturnNotes)
               .HasMaxLength(500);

        builder.Property(x => x.DamageDescription)
               .HasMaxLength(500);

        builder.Property(x => x.PenaltyAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
