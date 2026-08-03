using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class UsageViolationConfiguration : IEntityTypeConfiguration<UsageViolation>
{
    public void Configure(EntityTypeBuilder<UsageViolation> builder)
    {
        // Table Name
        builder.ToTable("usage_violation");

        // Property Configurations
        builder.Property(x => x.ViolationType)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.EvidenceJson)
               .HasMaxLength(100);

        builder.Property(x => x.PenaltyAction)
               .HasMaxLength(100);

        builder.Property(x => x.PenaltyAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.PenaltyAmountCurrency)
               .HasMaxLength(100);

        builder.Property(x => x.Status)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
