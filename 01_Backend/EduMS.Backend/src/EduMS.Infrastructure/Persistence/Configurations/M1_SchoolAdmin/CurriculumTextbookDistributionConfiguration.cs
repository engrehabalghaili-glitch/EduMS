using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class CurriculumTextbookDistributionConfiguration : IEntityTypeConfiguration<CurriculumTextbookDistribution>
{
    public void Configure(EntityTypeBuilder<CurriculumTextbookDistribution> builder)
    {
        // Table Name
        builder.ToTable("curriculum_textbook_distribution");

        // Property Configurations
        builder.Property(x => x.TextbookCode)
               .HasMaxLength(100);

        builder.Property(x => x.TextbookTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.TextbookTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.UnitCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalValueAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.WarehouseLocationCode)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
