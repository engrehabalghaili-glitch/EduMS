using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetCategoryConfiguration : IEntityTypeConfiguration<AssetCategory>
{
    public void Configure(EntityTypeBuilder<AssetCategory> builder)
    {
        // Table Name
        builder.ToTable("asset_category");

        // Property Configurations
        builder.Property(x => x.CategoryCode)
               .HasMaxLength(100);

        builder.Property(x => x.CategoryNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.CategoryNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.FullHierarchyPath)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        builder.Property(x => x.DefaultDepreciationRate)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
