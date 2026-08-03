using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PrivilegeRuleConfiguration : IEntityTypeConfiguration<PrivilegeRule>
{
    public void Configure(EntityTypeBuilder<PrivilegeRule> builder)
    {
        // Table Name
        builder.ToTable("privilege_rule");

        // Property Configurations
        builder.Property(x => x.RuleCode)
               .HasMaxLength(100);

        builder.Property(x => x.RuleNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.RuleNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.RuleCategory)
               .HasMaxLength(100);

        builder.Property(x => x.AppliesToType)
               .HasMaxLength(100);

        builder.Property(x => x.ConditionJson)
               .HasMaxLength(100);

        builder.Property(x => x.TriggerAction)
               .HasMaxLength(100);

        builder.Property(x => x.ActionParametersJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
