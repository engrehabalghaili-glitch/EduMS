using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SelfServicePortalRequestConfiguration : IEntityTypeConfiguration<SelfServicePortalRequest>
{
    public void Configure(EntityTypeBuilder<SelfServicePortalRequest> builder)
    {
        // Table Name
        builder.ToTable("self_service_portal_request");

        // Property Configurations
        builder.Property(x => x.RequestTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.RequestDetailsText)
               .HasMaxLength(100);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.AttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
