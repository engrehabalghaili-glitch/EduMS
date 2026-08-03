using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AcademicBranchConfigLogConfiguration : IEntityTypeConfiguration<AcademicBranchConfigLog>
{
    public void Configure(EntityTypeBuilder<AcademicBranchConfigLog> builder)
    {
        // Table Name
        builder.ToTable("academic_branch_config_log");

        // Property Configurations
        builder.Property(x => x.ConfigKey)
               .HasMaxLength(100);

        builder.Property(x => x.ConfigValue)
               .HasMaxLength(100);

        builder.Property(x => x.PreviousValue)
               .HasMaxLength(100);

        builder.Property(x => x.ChangeReason)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
