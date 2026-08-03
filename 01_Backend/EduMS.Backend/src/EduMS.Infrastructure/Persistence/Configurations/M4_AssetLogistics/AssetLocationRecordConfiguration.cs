using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetLocationRecordConfiguration : IEntityTypeConfiguration<AssetLocationRecord>
{
    public void Configure(EntityTypeBuilder<AssetLocationRecord> builder)
    {
        // Table Name
        builder.ToTable("asset_location_record");

        // Property Configurations
        builder.Property(x => x.LocationCode)
               .HasMaxLength(100);

        builder.Property(x => x.LocationNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.LocationNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.BuildingName)
               .HasMaxLength(100);

        builder.Property(x => x.RoomNumber)
               .HasMaxLength(100);

        builder.Property(x => x.MapReference)
               .HasMaxLength(100);

        builder.Property(x => x.QrCode)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
