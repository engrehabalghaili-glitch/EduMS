using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class InventoryPlanConfiguration : IEntityTypeConfiguration<InventoryPlan>
{
    public void Configure(EntityTypeBuilder<InventoryPlan> builder)
    {
        // Table Name
        builder.ToTable("inventory_plan");

        // Property Configurations
        builder.Property(x => x.PlanNumber)
               .HasMaxLength(100);

        builder.Property(x => x.PlanNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.AssignedTeamMembersJson)
               .HasMaxLength(100);

        builder.Property(x => x.Instructions)
               .HasMaxLength(100);

        builder.Property(x => x.CompletionPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
