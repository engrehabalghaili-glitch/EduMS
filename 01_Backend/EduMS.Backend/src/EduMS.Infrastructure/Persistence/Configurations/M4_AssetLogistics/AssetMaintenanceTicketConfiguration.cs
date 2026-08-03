using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetMaintenanceTicketConfiguration : IEntityTypeConfiguration<AssetMaintenanceTicket>
{
    public void Configure(EntityTypeBuilder<AssetMaintenanceTicket> builder)
    {
        // Table Name
        builder.ToTable("asset_maintenance_ticket");

        // Property Configurations
        builder.Property(x => x.TicketNumber)
               .HasMaxLength(100);

        builder.Property(x => x.IssueDescriptionText)
               .HasMaxLength(500);

        builder.Property(x => x.Diagnosis)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.ResolutionDetails)
               .HasMaxLength(100);

        builder.Property(x => x.ResolutionCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
