using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetLoanTrackingAlertConfiguration : IEntityTypeConfiguration<AssetLoanTrackingAlert>
{
    public void Configure(EntityTypeBuilder<AssetLoanTrackingAlert> builder)
    {
        // Table Name
        builder.ToTable("asset_loan_tracking_alert");

        // Property Configurations
        builder.Property(x => x.AlertMessageText)
               .HasMaxLength(100);

        builder.Property(x => x.SentToContact)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
