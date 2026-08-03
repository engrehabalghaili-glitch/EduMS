using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class BehaviorPermissionConfiguration : IEntityTypeConfiguration<BehaviorPermission>
{
    public void Configure(EntityTypeBuilder<BehaviorPermission> builder)
    {
        // Table Name
        builder.ToTable("behavior_permission");

        // Property Configurations
        builder.Property(x => x.PermissionKey)
               .HasMaxLength(100);

        builder.Property(x => x.PermissionNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.PermissionNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Category)
               .HasMaxLength(100);

        builder.Property(x => x.AllowedRolesJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
