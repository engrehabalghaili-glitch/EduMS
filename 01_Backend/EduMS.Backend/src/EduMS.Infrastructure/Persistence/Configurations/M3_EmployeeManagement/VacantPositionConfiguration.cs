using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class VacantPositionConfiguration : IEntityTypeConfiguration<VacantPosition>
{
    public void Configure(EntityTypeBuilder<VacantPosition> builder)
    {
        // Table Name
        builder.ToTable("vacant_position");

        // Property Configurations
        builder.Property(x => x.PositionCode)
               .HasMaxLength(100);

        builder.Property(x => x.PositionTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.PositionTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.RequiredQualification)
               .HasMaxLength(100);

        builder.Property(x => x.SalaryRangeMin)
               .HasPrecision(18, 2);

        builder.Property(x => x.SalaryRangeMax)
               .HasPrecision(18, 2);

        builder.Property(x => x.SpecialRequirements)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
