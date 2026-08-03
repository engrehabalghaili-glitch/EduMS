using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolCanteenItemConfiguration : IEntityTypeConfiguration<SchoolCanteenItem>
{
    public void Configure(EntityTypeBuilder<SchoolCanteenItem> builder)
    {
        // Table Name
        builder.ToTable("school_canteen_item");

        // Property Configurations
        builder.Property(x => x.ItemCode)
               .HasMaxLength(100);

        builder.Property(x => x.ItemNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.UnitPrice)
               .HasPrecision(18, 2);

        builder.Property(x => x.ItemNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.CostPrice)
               .HasPrecision(18, 2);

        builder.Property(x => x.BarcodeNumber)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
