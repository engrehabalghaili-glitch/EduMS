using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetDepreciationConfiguration : IEntityTypeConfiguration<AssetDepreciation>
{
    public void Configure(EntityTypeBuilder<AssetDepreciation> builder)
    {
        // Table Name
        builder.ToTable("asset_depreciation");

        // Property Configurations
        builder.Property(x => x.DepreciationRate)
               .HasPrecision(18, 2);

        builder.Property(x => x.CurrentBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.AccumulatedDepreciation)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetBookValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.DepreciableAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.LastDepreciationPeriod)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
