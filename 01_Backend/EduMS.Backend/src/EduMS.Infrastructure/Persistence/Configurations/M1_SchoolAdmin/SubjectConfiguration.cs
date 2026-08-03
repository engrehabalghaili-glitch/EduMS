using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        // Table Name
        builder.ToTable("subject");

        // Property Configurations
        builder.Property(x => x.SubjectCode)
               .HasMaxLength(100);

        builder.Property(x => x.SubjectNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.SubjectNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Specialization)
               .HasMaxLength(100);

        builder.Property(x => x.TextbookTitle)
               .HasMaxLength(100);

        builder.Property(x => x.TotalMarks)
               .HasPrecision(18, 2);

        builder.Property(x => x.PassingMarks)
               .HasPrecision(18, 2);

        builder.Property(x => x.CreditHours)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
