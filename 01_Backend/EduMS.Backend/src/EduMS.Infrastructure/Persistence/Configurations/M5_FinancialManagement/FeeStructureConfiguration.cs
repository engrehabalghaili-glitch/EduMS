using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class FeeStructureConfiguration : IEntityTypeConfiguration<FeeStructure>
{
    public void Configure(EntityTypeBuilder<FeeStructure> builder)
    {
        // Table Name
        builder.ToTable("fee_structure");

        // Property Configurations
        builder.Property(x => x.FeeCode)
               .HasMaxLength(100);

        builder.Property(x => x.FeeNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FeeNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Amount)
               .HasPrecision(18, 2);

        builder.Property(x => x.AcademicYear)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
