using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ClassSectionConfiguration : IEntityTypeConfiguration<ClassSection>
{
    public void Configure(EntityTypeBuilder<ClassSection> builder)
    {
        // Table Name
        builder.ToTable("class_section");

        // Property Configurations
        builder.Property(x => x.SectionCode)
               .HasMaxLength(100);

        builder.Property(x => x.SectionNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.SectionNameEn)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
