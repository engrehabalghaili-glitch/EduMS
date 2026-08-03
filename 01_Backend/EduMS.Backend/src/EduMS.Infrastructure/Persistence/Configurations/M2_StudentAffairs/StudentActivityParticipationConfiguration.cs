using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentActivityParticipationConfiguration : IEntityTypeConfiguration<StudentActivityParticipation>
{
    public void Configure(EntityTypeBuilder<StudentActivityParticipation> builder)
    {
        // Table Name
        builder.ToTable("student_activity_participation");

        // Property Configurations
        builder.Property(x => x.ActivityNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.AchievementDetail)
               .HasMaxLength(100);

        builder.Property(x => x.ScoreBonus)
               .HasPrecision(18, 2);

        builder.Property(x => x.ActivityNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ParticipationRole)
               .HasMaxLength(100);

        builder.Property(x => x.AwardLevel)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
