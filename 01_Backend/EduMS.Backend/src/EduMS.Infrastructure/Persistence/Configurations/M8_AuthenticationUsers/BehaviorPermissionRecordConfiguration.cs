using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class BehaviorPermissionRecordConfiguration : IEntityTypeConfiguration<BehaviorPermissionRecord>
{
    public void Configure(EntityTypeBuilder<BehaviorPermissionRecord> builder)
    {
        // Table Name
        builder.ToTable("behavior_permission_record");

        // Property Configurations
        builder.Property(x => x.Category)
               .HasMaxLength(100);

        builder.Property(x => x.SubCategory)
               .HasMaxLength(100);

        builder.Property(x => x.PermissionKey)
               .HasMaxLength(100);

        builder.Property(x => x.AllowedActionsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Scope)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
