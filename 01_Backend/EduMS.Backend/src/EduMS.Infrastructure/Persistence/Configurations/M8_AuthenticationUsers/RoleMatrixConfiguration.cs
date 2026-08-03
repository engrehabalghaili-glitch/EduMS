using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class RoleMatrixConfiguration : IEntityTypeConfiguration<RoleMatrix>
{
    public void Configure(EntityTypeBuilder<RoleMatrix> builder)
    {
        // Table Name
        builder.ToTable("role_matrix");

        // Property Configurations
        builder.Property(x => x.RoleCode)
               .HasMaxLength(100);

        builder.Property(x => x.RoleNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.RoleNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.PermissionsJson)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
