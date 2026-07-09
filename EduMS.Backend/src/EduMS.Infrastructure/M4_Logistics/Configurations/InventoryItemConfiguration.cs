using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M4_Logistics.Configurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.ToTable("INVENTORY_ITEM");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).HasColumnName("INVENTORY_ITEM_ID");

        builder.Property(i => i.WarehouseId)
            .HasColumnName("WAREHOUSE_ID")
            .IsRequired();

        builder.Property(i => i.ItemName)
            .HasColumnName("ITEM_NAME")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(i => i.ItemCode)
            .HasColumnName("ITEM_CODE")
            .HasMaxLength(50);

        builder.Property(i => i.Quantity)
            .HasColumnName("QUANTITY")
            .IsRequired();

        builder.Property(i => i.UnitOfMeasure)
            .HasColumnName("UNIT_OF_MEASURE")
            .HasMaxLength(30)
            .IsRequired();

        // Relationship mapping
        builder.HasOne(i => i.Warehouse)
            .WithMany(w => w.InventoryItems)
            .HasForeignKey(i => i.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Audit Properties Configuration
        builder.Property(i => i.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(i => i.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(i => i.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(i => i.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(i => i.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(i => i.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(i => i.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(i => i.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(i => i.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(i => i.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
