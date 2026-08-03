using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ReferenceCodingLookupConfiguration : IEntityTypeConfiguration<ReferenceCodingLookup>
{
    public void Configure(EntityTypeBuilder<ReferenceCodingLookup> builder)
    {
        // Table Name
        builder.ToTable("reference_coding_lookup");

        // Property Configurations
        builder.Property(x => x.CodeType)
               .HasMaxLength(100);

        builder.Property(x => x.CodeKey)
               .HasMaxLength(100);

        builder.Property(x => x.CodeValueAr)
               .HasMaxLength(100);

        builder.Property(x => x.CodeValueEn)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        builder.Property(x => x.DescriptionEn)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
