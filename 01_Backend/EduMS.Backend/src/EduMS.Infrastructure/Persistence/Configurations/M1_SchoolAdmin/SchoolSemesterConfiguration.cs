using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolSemesterConfiguration : IEntityTypeConfiguration<SchoolSemester>
{
    public void Configure(EntityTypeBuilder<SchoolSemester> builder)
    {
        // Table Name
        builder.ToTable("school_semester");

        // Property Configurations
        builder.Property(x => x.SemesterType)
               .HasMaxLength(100);

        builder.Property(x => x.SemesterNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.SemesterNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
