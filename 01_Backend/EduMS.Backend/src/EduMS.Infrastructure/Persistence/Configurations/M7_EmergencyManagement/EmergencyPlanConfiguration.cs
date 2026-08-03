using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyPlanConfiguration : IEntityTypeConfiguration<EmergencyPlan>
{
    public void Configure(EntityTypeBuilder<EmergencyPlan> builder)
    {
        // Table Name
        builder.ToTable("emergency_plan");

        // Property Configurations
        builder.Property(x => x.PlanCode)
               .HasMaxLength(100);

        builder.Property(x => x.PlanTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.PlanTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.EvacuationProcedureSummary)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
