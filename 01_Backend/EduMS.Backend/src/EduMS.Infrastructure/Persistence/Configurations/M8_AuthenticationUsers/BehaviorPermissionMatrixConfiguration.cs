using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class BehaviorPermissionMatrixConfiguration : IEntityTypeConfiguration<BehaviorPermissionMatrix>
{
    public void Configure(EntityTypeBuilder<BehaviorPermissionMatrix> builder)
    {
        // Table Name
        builder.ToTable("behavior_permission_matrix");

        // Property Configurations
        builder.Property(x => x.BehaviorLevel)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
