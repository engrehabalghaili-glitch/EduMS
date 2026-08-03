using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmployeePerformanceReviewConfiguration : IEntityTypeConfiguration<EmployeePerformanceReview>
{
    public void Configure(EntityTypeBuilder<EmployeePerformanceReview> builder)
    {
        // Table Name
        builder.ToTable("employee_performance_review");

        // Property Configurations
        builder.Property(x => x.OverallScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.PerformanceLevel)
               .HasMaxLength(100);

        builder.Property(x => x.KpiScoresJson)
               .HasMaxLength(100);

        builder.Property(x => x.StrengthsText)
               .HasMaxLength(100);

        builder.Property(x => x.AreasForImprovementText)
               .HasMaxLength(100);

        builder.Property(x => x.DevelopmentPlanText)
               .HasMaxLength(100);

        builder.Property(x => x.EmployeeResponseText)
               .HasMaxLength(100);

        builder.Property(x => x.DisputeReason)
               .HasMaxLength(500);

        builder.Property(x => x.FinalDecisionText)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
