using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class FeeTypeConfiguration : IEntityTypeConfiguration<FeeType>
{
    public void Configure(EntityTypeBuilder<FeeType> builder)
    {
        // Table Name
        builder.ToTable("fee_type");

        // Property Configurations
        builder.Property(x => x.FeeCode)
               .HasMaxLength(100);

        builder.Property(x => x.FeeNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FeeNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Amount)
               .HasPrecision(18, 2);

        builder.Property(x => x.DefaultAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.BillingFrequency)
               .HasMaxLength(100);

        builder.Property(x => x.TaxPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.DiscountPercentageAllowed)
               .HasPrecision(18, 2);

        builder.Property(x => x.RefundPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.RecurrenceType)
               .HasMaxLength(100);

        builder.Property(x => x.AppliesToGradesJson)
               .HasMaxLength(100);

        builder.Property(x => x.AppliesToNationalitiesJson)
               .HasMaxLength(100);

        builder.Property(x => x.AppliesToStudentTypesJson)
               .HasMaxLength(100);

        builder.Property(x => x.DescriptionAr)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
