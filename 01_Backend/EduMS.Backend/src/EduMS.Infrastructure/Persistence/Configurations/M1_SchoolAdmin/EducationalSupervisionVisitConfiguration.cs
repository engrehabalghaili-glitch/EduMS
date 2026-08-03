using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EducationalSupervisionVisitConfiguration : IEntityTypeConfiguration<EducationalSupervisionVisit>
{
    public void Configure(EntityTypeBuilder<EducationalSupervisionVisit> builder)
    {
        // Table Name
        builder.ToTable("educational_supervision_visit");

        // Property Configurations
        builder.Property(x => x.SupervisorName)
               .HasMaxLength(100);

        builder.Property(x => x.VisitPurpose)
               .HasMaxLength(100);

        builder.Property(x => x.EvaluationScore)
               .HasPrecision(18, 2);

        builder.Property(x => x.Recommendations)
               .HasMaxLength(100);

        builder.Property(x => x.ActionItemsDetail)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
