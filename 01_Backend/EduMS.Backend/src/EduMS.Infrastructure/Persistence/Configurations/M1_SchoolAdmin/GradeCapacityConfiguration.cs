using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class GradeCapacityConfiguration : IEntityTypeConfiguration<GradeCapacity>
{
    public void Configure(EntityTypeBuilder<GradeCapacity> builder)
    {
        // Table Name
        builder.ToTable("grade_capacity");

        // Property Configurations
        builder.Property(x => x.GradeLevelCode)
               .HasMaxLength(100);

        builder.Property(x => x.GradeNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.GradeNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
