using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentExemptionConfiguration : IEntityTypeConfiguration<StudentExemption>
{
    public void Configure(EntityTypeBuilder<StudentExemption> builder)
    {
        // Table Name
        builder.ToTable("student_exemption");

        // Property Configurations
        builder.Property(x => x.DiscountPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.ReasonDescription)
               .HasMaxLength(500);

        builder.Property(x => x.ExemptionCode)
               .HasMaxLength(100);

        builder.Property(x => x.SupportingDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.AnnualMaxDiscountAmount)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
