using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StaffCustodySummaryConfiguration : IEntityTypeConfiguration<StaffCustodySummary>
{
    public void Configure(EntityTypeBuilder<StaffCustodySummary> builder)
    {
        // Table Name
        builder.ToTable("staff_custody_summary");

        // Property Configurations
        builder.Property(x => x.CustodySummaryJson)
               .HasMaxLength(100);

        builder.Property(x => x.TotalItemsCount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalEstimatedValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.ClearanceNotes)
               .HasMaxLength(500);

        builder.Property(x => x.ClearanceDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
