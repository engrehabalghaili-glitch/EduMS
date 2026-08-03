using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class OfficePermissionConfiguration : IEntityTypeConfiguration<OfficePermission>
{
    public void Configure(EntityTypeBuilder<OfficePermission> builder)
    {
        // Table Name
        builder.ToTable("office_permission");

        // Property Configurations
        builder.Property(x => x.PermissionKey)
               .HasMaxLength(100);

        builder.Property(x => x.PermissionNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.PermissionNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ScopeType)
               .HasMaxLength(100);

        builder.Property(x => x.ScopeTargetJson)
               .HasMaxLength(100);

        builder.Property(x => x.AllowedRolesJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
