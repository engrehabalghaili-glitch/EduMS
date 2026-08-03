using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SystemPermissionConfiguration : IEntityTypeConfiguration<SystemPermission>
{
    public void Configure(EntityTypeBuilder<SystemPermission> builder)
    {
        // Table Name
        builder.ToTable("system_permission");

        // Property Configurations
        builder.Property(x => x.PermissionKey)
               .HasMaxLength(100);

        builder.Property(x => x.Module)
               .HasMaxLength(100);

        builder.Property(x => x.SubModule)
               .HasMaxLength(100);

        builder.Property(x => x.ActionType)
               .HasMaxLength(100);

        builder.Property(x => x.DefaultScope)
               .HasMaxLength(100);

        builder.Property(x => x.NameAr)
               .HasMaxLength(100);

        builder.Property(x => x.NameEn)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        builder.Property(x => x.RiskLevel)
               .HasMaxLength(100);

        builder.Property(x => x.ConditionsJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
