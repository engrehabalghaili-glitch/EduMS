using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AcademicWarningPolicyConfiguration : IEntityTypeConfiguration<AcademicWarningPolicy>
{
    public void Configure(EntityTypeBuilder<AcademicWarningPolicy> builder)
    {
        // Table Name
        builder.ToTable("academic_warning_policy");

        // Property Configurations
        builder.Property(x => x.PolicyCode)
               .HasMaxLength(100);

        builder.Property(x => x.PolicyTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.ThresholdValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.PolicyTitleEn)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
