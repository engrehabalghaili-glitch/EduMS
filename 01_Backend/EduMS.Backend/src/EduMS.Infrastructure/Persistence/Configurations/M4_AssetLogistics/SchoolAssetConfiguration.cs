using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolAssetConfiguration : IEntityTypeConfiguration<SchoolAsset>
{
    public void Configure(EntityTypeBuilder<SchoolAsset> builder)
    {
        // Table Name
        builder.ToTable("school_asset");

        // Property Configurations
        builder.Property(x => x.AssetUniqueCode)
               .HasMaxLength(100);

        builder.Property(x => x.AssetNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.AssetNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.AssetTag)
               .HasMaxLength(100);

        builder.Property(x => x.SerialNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ModelNumber)
               .HasMaxLength(100);

        builder.Property(x => x.Manufacturer)
               .HasMaxLength(100);

        builder.Property(x => x.Brand)
               .HasMaxLength(100);

        builder.Property(x => x.AcquisitionCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.SupplierName)
               .HasMaxLength(100);

        builder.Property(x => x.PurchaseOrderReference)
               .HasMaxLength(100);

        builder.Property(x => x.InsurancePolicyNumber)
               .HasMaxLength(100);

        builder.Property(x => x.SalvageValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.CurrentBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.Barcode)
               .HasMaxLength(100);

        builder.Property(x => x.QrCode)
               .HasMaxLength(100);

        builder.Property(x => x.RfidTag)
               .HasMaxLength(100);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
