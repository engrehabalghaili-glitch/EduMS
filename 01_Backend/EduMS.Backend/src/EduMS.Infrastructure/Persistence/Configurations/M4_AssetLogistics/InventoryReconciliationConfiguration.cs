using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class InventoryReconciliationConfiguration : IEntityTypeConfiguration<InventoryReconciliation>
{
    public void Configure(EntityTypeBuilder<InventoryReconciliation> builder)
    {
        // Table Name
        builder.ToTable("inventory_reconciliation");

        // Property Configurations
        builder.Property(x => x.ActualLocationText)
               .HasMaxLength(100);

        builder.Property(x => x.ReasonForDiscrepancy)
               .HasMaxLength(500);

        builder.Property(x => x.InvestigationNotes)
               .HasMaxLength(500);

        builder.Property(x => x.CorrectiveAction)
               .HasMaxLength(100);

        builder.Property(x => x.ResolutionNotes)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
