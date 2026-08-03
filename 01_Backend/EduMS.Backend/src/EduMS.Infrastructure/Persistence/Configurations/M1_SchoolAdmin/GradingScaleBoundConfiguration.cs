using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class GradingScaleBoundConfiguration : IEntityTypeConfiguration<GradingScaleBound>
{
    public void Configure(EntityTypeBuilder<GradingScaleBound> builder)
    {
        // Table Name
        builder.ToTable("grading_scale_bound");

        // Property Configurations
        builder.Property(x => x.ScaleName)
               .HasMaxLength(100);

        builder.Property(x => x.LetterCode)
               .HasMaxLength(100);

        builder.Property(x => x.MinPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.MaxPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.GradePointValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        builder.Property(x => x.DescriptionEn)
               .HasMaxLength(500);

        builder.Property(x => x.ScaleCode)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
