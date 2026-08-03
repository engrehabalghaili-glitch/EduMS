using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EnrollmentFinancialLinkConfiguration : IEntityTypeConfiguration<EnrollmentFinancialLink>
{
    public void Configure(EntityTypeBuilder<EnrollmentFinancialLink> builder)
    {
        // Table Name
        builder.ToTable("enrollment_financial_link");

        // Property Configurations
        builder.Property(x => x.TuitionFeeDue)
               .HasPrecision(18, 2);

        builder.Property(x => x.DiscountApplied)
               .HasPrecision(18, 2);

        builder.Property(x => x.ExemptionApplied)
               .HasPrecision(18, 2);

        builder.Property(x => x.NetPayable)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
