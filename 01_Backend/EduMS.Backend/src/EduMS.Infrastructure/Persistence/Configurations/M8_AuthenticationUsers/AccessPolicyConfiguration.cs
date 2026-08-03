using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AccessPolicyConfiguration : IEntityTypeConfiguration<AccessPolicy>
{
    public void Configure(EntityTypeBuilder<AccessPolicy> builder)
    {
        // Table Name
        builder.ToTable("access_policy");

        // Property Configurations
        builder.Property(x => x.PolicyCode)
               .HasMaxLength(100);

        builder.Property(x => x.PolicyNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.PolicyNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.PolicyRuleJson)
               .HasMaxLength(100);

        builder.Property(x => x.AppliesToType)
               .HasMaxLength(100);

        builder.Property(x => x.AppliesToIdsJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
