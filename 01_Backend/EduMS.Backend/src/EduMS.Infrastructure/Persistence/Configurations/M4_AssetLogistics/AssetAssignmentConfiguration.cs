using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetAssignmentConfiguration : IEntityTypeConfiguration<AssetAssignment>
{
    public void Configure(EntityTypeBuilder<AssetAssignment> builder)
    {
        // Table Name
        builder.ToTable("asset_assignment");

        // Property Configurations
        builder.Property(x => x.AssigneeName)
               .HasMaxLength(100);

        builder.Property(x => x.AssignmentReason)
               .HasMaxLength(500);

        builder.Property(x => x.ConditionNotesAtAssignment)
               .HasMaxLength(500);

        builder.Property(x => x.ConditionNotesAtReturn)
               .HasMaxLength(500);

        builder.Property(x => x.PenaltyAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
