using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetSuspensionRequestConfiguration : IEntityTypeConfiguration<AssetSuspensionRequest>
{
    public void Configure(EntityTypeBuilder<AssetSuspensionRequest> builder)
    {
        // Table Name
        builder.ToTable("asset_suspension_request");

        // Property Configurations
        builder.Property(x => x.Reason)
               .HasMaxLength(500);

        builder.Property(x => x.ReasonDetails)
               .HasMaxLength(500);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.ApprovalStatus)
               .HasMaxLength(100);

        builder.Property(x => x.ApprovalNotes)
               .HasMaxLength(500);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.RevokeReason)
               .HasMaxLength(500);

        builder.Property(x => x.Status)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
