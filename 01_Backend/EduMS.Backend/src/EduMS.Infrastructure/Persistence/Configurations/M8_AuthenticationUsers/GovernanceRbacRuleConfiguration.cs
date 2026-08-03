using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class GovernanceRbacRuleConfiguration : IEntityTypeConfiguration<GovernanceRbacRule>
{
    public void Configure(EntityTypeBuilder<GovernanceRbacRule> builder)
    {
        // Table Name
        builder.ToTable("governance_rbac_rule");

        // Property Configurations
        builder.Property(x => x.AllowedAction)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
