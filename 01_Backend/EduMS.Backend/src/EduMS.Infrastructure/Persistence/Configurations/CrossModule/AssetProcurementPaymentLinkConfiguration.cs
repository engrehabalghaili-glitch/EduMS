using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetProcurementPaymentLinkConfiguration : IEntityTypeConfiguration<AssetProcurementPaymentLink>
{
    public void Configure(EntityTypeBuilder<AssetProcurementPaymentLink> builder)
    {
        // Table Name
        builder.ToTable("asset_procurement_payment_link");

        // Property Configurations
        builder.Property(x => x.PaidAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
