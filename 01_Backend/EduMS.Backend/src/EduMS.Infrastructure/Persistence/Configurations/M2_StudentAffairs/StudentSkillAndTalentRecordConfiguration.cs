using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentSkillAndTalentRecordConfiguration : IEntityTypeConfiguration<StudentSkillAndTalentRecord>
{
    public void Configure(EntityTypeBuilder<StudentSkillAndTalentRecord> builder)
    {
        // Table Name
        builder.ToTable("student_skill_and_talent_record");

        // Property Configurations
        builder.Property(x => x.TalentTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.TalentTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.DevelopmentPlanDescription)
               .HasMaxLength(500);

        builder.Property(x => x.PortfolioAttachmentUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
