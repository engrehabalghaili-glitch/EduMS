using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeTerminationConfiguration : IEntityTypeConfiguration<EmployeeTermination>
{
    public void Configure(EntityTypeBuilder<EmployeeTermination> builder)
    {
        // Table Name
        builder.ToTable("employee_termination");

        // Property Configurations
        builder.Property(x => x.TerminationReferenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TerminationReason)
               .HasMaxLength(500);

        builder.Property(x => x.GratuityAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.FinalSalarySettlement)
               .HasPrecision(18, 2);

        builder.Property(x => x.DecisionDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
