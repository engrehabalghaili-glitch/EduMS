using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M4_Logistics.Configurations;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("WAREHOUSE");

        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id).HasColumnName("WAREHOUSE_ID");

        builder.Property(w => w.WarehouseName)
            .HasColumnName("WAREHOUSE_NAME")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(w => w.OwnerType)
            .HasColumnName("OWNER_TYPE")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(w => w.OwnerId)
            .HasColumnName("OWNER_ID")
            .IsRequired();

        builder.Property(w => w.LocationAddress)
            .HasColumnName("LOCATION_ADDRESS")
            .HasMaxLength(255);

        builder.Property(w => w.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        // Audit Properties Configuration
        builder.Property(w => w.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(w => w.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(w => w.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(w => w.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(w => w.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(w => w.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(w => w.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(w => w.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(w => w.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(w => w.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
