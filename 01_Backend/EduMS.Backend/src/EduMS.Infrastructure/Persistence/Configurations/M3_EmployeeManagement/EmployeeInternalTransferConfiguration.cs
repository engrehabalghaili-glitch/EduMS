using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeeInternalTransferConfiguration : IEntityTypeConfiguration<EmployeeInternalTransfer>
{
    public void Configure(EntityTypeBuilder<EmployeeInternalTransfer> builder)
    {
        // Table Name
        builder.ToTable("employee_internal_transfer");

        // Property Configurations
        builder.Property(x => x.TransferRequestNumber)
               .HasMaxLength(100);

        builder.Property(x => x.FromJobTitle)
               .HasMaxLength(100);

        builder.Property(x => x.ToJobTitle)
               .HasMaxLength(100);

        builder.Property(x => x.TransferReason)
               .HasMaxLength(500);

        builder.Property(x => x.RejectionReason)
               .HasMaxLength(500);

        builder.Property(x => x.DecisionDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
