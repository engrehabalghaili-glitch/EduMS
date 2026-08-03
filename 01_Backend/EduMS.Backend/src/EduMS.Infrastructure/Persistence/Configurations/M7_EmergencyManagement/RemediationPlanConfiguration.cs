using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class RemediationPlanConfiguration : IEntityTypeConfiguration<RemediationPlan>
{
    public void Configure(EntityTypeBuilder<RemediationPlan> builder)
    {
        // Table Name
        builder.ToTable("remediation_plan");

        // Property Configurations
        builder.Property(x => x.PlanNumber)
               .HasMaxLength(100);

        builder.Property(x => x.PlanName)
               .HasMaxLength(100);

        builder.Property(x => x.SelectedOption)
               .HasMaxLength(100);

        builder.Property(x => x.OptionDetails)
               .HasMaxLength(100);

        builder.Property(x => x.Objectives)
               .HasMaxLength(100);

        builder.Property(x => x.ActionStepsJson)
               .HasMaxLength(100);

        builder.Property(x => x.EstimatedBudget)
               .HasPrecision(18, 2);

        builder.Property(x => x.ActualCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.ExecutionTeamJson)
               .HasMaxLength(100);

        builder.Property(x => x.ProgressPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.CompletionReport)
               .HasMaxLength(100);

        builder.Property(x => x.LessonsLearned)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
