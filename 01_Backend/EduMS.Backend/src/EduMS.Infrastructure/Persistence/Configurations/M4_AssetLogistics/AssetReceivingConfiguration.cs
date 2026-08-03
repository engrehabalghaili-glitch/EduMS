using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetReceivingConfiguration : IEntityTypeConfiguration<AssetReceiving>
{
    public void Configure(EntityTypeBuilder<AssetReceiving> builder)
    {
        // Table Name
        builder.ToTable("asset_receiving");

        // Property Configurations
        builder.Property(x => x.ReceivingNumber)
               .HasMaxLength(100);

        builder.Property(x => x.DeliveryNoteNumber)
               .HasMaxLength(100);

        builder.Property(x => x.DeliveryCompany)
               .HasMaxLength(100);

        builder.Property(x => x.InspectionNotes)
               .HasMaxLength(500);

        builder.Property(x => x.ReceivedItemsDetailsJson)
               .HasMaxLength(100);

        builder.Property(x => x.RejectedItemsJson)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
