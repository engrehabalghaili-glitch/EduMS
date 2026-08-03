using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeViolationConfiguration : IEntityTypeConfiguration<EmployeeViolation>
{
    public void Configure(EntityTypeBuilder<EmployeeViolation> builder)
    {
        // Table Name
        builder.ToTable("employee_violation");

        // Property Configurations
        builder.Property(x => x.ViolationReferenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ViolationDescriptionAr)
               .HasMaxLength(500);

        builder.Property(x => x.SupportingDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.PenaltyDeductionAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.InvestigationNotes)
               .HasMaxLength(500);

        builder.Property(x => x.DecisionText)
               .HasMaxLength(100);

        builder.Property(x => x.AppealResult)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
