using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class OrganizationalSectorConfiguration : IEntityTypeConfiguration<OrganizationalSector>
{
    public void Configure(EntityTypeBuilder<OrganizationalSector> builder)
    {
        // Table Name
        builder.ToTable("organizational_sector");

        // Property Configurations
        builder.Property(x => x.SectorCode)
               .HasMaxLength(100);

        builder.Property(x => x.SectorNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.SectorNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.CostCenterCode)
               .HasMaxLength(100);

        builder.Property(x => x.AnnualHrBudget)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
