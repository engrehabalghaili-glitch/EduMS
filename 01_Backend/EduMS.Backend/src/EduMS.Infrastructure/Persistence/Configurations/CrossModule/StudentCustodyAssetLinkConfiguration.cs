using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentCustodyAssetLinkConfiguration : IEntityTypeConfiguration<StudentCustodyAssetLink>
{
    public void Configure(EntityTypeBuilder<StudentCustodyAssetLink> builder)
    {
        // Table Name
        builder.ToTable("student_custody_asset_link");

        // Property Configurations
        builder.Property(x => x.ReplacementValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
