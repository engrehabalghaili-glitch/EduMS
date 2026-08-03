using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DirectorateConfiguration : IEntityTypeConfiguration<Directorate>
{
    public void Configure(EntityTypeBuilder<Directorate> builder)
    {
        // Table Name
        builder.ToTable("directorate");

        // Property Configurations
        builder.Property(x => x.DirectorateCode)
               .HasMaxLength(100);

        builder.Property(x => x.DirectorateNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.DirectorateNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Address)
               .HasMaxLength(500);

        builder.Property(x => x.ContactPhone)
               .HasMaxLength(100);

        builder.Property(x => x.ContactEmail)
               .HasMaxLength(100);

        builder.Property(x => x.DirectorName)
               .HasMaxLength(100);

        builder.Property(x => x.Governorate)
               .HasMaxLength(100);

        builder.Property(x => x.RegionCode)
               .HasMaxLength(100);

        builder.Property(x => x.SupervisoryScopeDescription)
               .HasMaxLength(500);

        builder.Property(x => x.AnnualBudgetLimit)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
