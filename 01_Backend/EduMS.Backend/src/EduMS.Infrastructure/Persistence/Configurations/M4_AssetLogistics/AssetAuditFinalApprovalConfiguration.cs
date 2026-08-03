using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetAuditFinalApprovalConfiguration : IEntityTypeConfiguration<AssetAuditFinalApproval>
{
    public void Configure(EntityTypeBuilder<AssetAuditFinalApproval> builder)
    {
        // Table Name
        builder.ToTable("asset_audit_final_approval");

        // Property Configurations
        builder.Property(x => x.ApprovalDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.SummaryOfChanges)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
