using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolAcademicYearConfiguration : IEntityTypeConfiguration<SchoolAcademicYear>
{
    public void Configure(EntityTypeBuilder<SchoolAcademicYear> builder)
    {
        // Table Name
        builder.ToTable("school_academic_year");

        // Property Configurations
        builder.Property(x => x.YearCode)
               .HasMaxLength(100);

        builder.Property(x => x.YearNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.YearNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
