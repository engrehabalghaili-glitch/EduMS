using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolCurriculumPlanConfiguration : IEntityTypeConfiguration<SchoolCurriculumPlan>
{
    public void Configure(EntityTypeBuilder<SchoolCurriculumPlan> builder)
    {
        // Table Name
        builder.ToTable("school_curriculum_plan");

        // Property Configurations
        builder.Property(x => x.PlanNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.PlanNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.PlanCode)
               .HasMaxLength(100);

        builder.Property(x => x.PlanVersion)
               .HasMaxLength(100);

        builder.Property(x => x.TotalCreditHours)
               .HasPrecision(18, 2);

        builder.Property(x => x.ApprovalDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
