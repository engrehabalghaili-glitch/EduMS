using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class VisitorEntryLogConfiguration : IEntityTypeConfiguration<VisitorEntryLog>
{
    public void Configure(EntityTypeBuilder<VisitorEntryLog> builder)
    {
        // Table Name
        builder.ToTable("visitor_entry_log");

        // Property Configurations
        builder.Property(x => x.VisitorFullName)
               .HasMaxLength(100);

        builder.Property(x => x.NationalIdOrPassport)
               .HasMaxLength(100);

        builder.Property(x => x.VisitPurpose)
               .HasMaxLength(100);

        builder.Property(x => x.VisitorBadgeNumber)
               .HasMaxLength(100);

        builder.Property(x => x.VisitorPhoneNumber)
               .HasMaxLength(100);

        builder.Property(x => x.VisitorOrganization)
               .HasMaxLength(100);

        builder.Property(x => x.SecurityGateNumber)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
