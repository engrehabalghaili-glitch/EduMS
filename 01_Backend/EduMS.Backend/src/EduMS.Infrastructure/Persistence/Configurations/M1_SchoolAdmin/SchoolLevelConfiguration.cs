using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolLevelConfiguration : IEntityTypeConfiguration<SchoolLevel>
{
    public void Configure(EntityTypeBuilder<SchoolLevel> builder)
    {
        // Table Name
        builder.ToTable("school_level");

        // Property Configurations
        builder.Property(x => x.LevelNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.LevelNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.StartGrade)
               .HasMaxLength(100);

        builder.Property(x => x.EndGrade)
               .HasMaxLength(100);

        builder.Property(x => x.AcademicTrack)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
