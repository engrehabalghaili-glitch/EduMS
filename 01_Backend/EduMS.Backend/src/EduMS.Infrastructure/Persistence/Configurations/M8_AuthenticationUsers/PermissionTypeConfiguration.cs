using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
{
    public void Configure(EntityTypeBuilder<PermissionType> builder)
    {
        // Table Name
        builder.ToTable("permission_type");

        // Property Configurations
        builder.Property(x => x.TypeCode)
               .HasMaxLength(100);

        builder.Property(x => x.TypeNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.TypeNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Category)
               .HasMaxLength(100);

        builder.Property(x => x.ScopeType)
               .HasMaxLength(100);

        builder.Property(x => x.RiskLevel)
               .HasMaxLength(100);

        builder.Property(x => x.ApprovalLevel)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
