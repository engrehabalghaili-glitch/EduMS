using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ClassroomOperationalRuleConfiguration : IEntityTypeConfiguration<ClassroomOperationalRule>
{
    public void Configure(EntityTypeBuilder<ClassroomOperationalRule> builder)
    {
        // Table Name
        builder.ToTable("classroom_operational_rule");

        // Property Configurations
        builder.Property(x => x.RuleCode)
               .HasMaxLength(100);

        builder.Property(x => x.RuleTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.RuleTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.MaxAllowedAbsencePercentage)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
