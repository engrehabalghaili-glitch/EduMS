using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class UserDirectPermissionConfiguration : IEntityTypeConfiguration<UserDirectPermission>
{
    public void Configure(EntityTypeBuilder<UserDirectPermission> builder)
    {
        // Table Name
        builder.ToTable("user_direct_permission");

        // Property Configurations
        builder.Property(x => x.ScopeOverride)
               .HasMaxLength(100);

        builder.Property(x => x.Reason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
