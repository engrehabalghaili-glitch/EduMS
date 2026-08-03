using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PermissionBaseModuleConfiguration : IEntityTypeConfiguration<PermissionBaseModule>
{
    public void Configure(EntityTypeBuilder<PermissionBaseModule> builder)
    {
        // Table Name
        builder.ToTable("permission_base_module");

        // Property Configurations
        builder.Property(x => x.ModuleCode)
               .HasMaxLength(100);

        builder.Property(x => x.ModuleNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ModuleNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.SectionCode)
               .HasMaxLength(100);

        builder.Property(x => x.SectionNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.SectionNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.DefaultPermissionsJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
