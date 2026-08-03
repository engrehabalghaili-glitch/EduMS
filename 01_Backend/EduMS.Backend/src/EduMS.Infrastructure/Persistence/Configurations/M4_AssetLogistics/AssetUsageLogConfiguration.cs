using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetUsageLogConfiguration : IEntityTypeConfiguration<AssetUsageLog>
{
    public void Configure(EntityTypeBuilder<AssetUsageLog> builder)
    {
        // Table Name
        builder.ToTable("asset_usage_log");

        // Property Configurations
        builder.Property(x => x.PurposeDetails)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
