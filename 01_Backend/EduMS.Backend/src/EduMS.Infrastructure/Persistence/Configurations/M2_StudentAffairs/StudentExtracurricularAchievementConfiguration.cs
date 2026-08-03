using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentExtracurricularAchievementConfiguration : IEntityTypeConfiguration<StudentExtracurricularAchievement>
{
    public void Configure(EntityTypeBuilder<StudentExtracurricularAchievement> builder)
    {
        // Table Name
        builder.ToTable("student_extracurricular_achievement");

        // Property Configurations
        builder.Property(x => x.CompetitionTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.CompetitionTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.OrganizingInstitutionName)
               .HasMaxLength(100);

        builder.Property(x => x.AwardDescription)
               .HasMaxLength(500);

        builder.Property(x => x.MonetaryPrizeAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.CertificateOrMedalPhotoUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
