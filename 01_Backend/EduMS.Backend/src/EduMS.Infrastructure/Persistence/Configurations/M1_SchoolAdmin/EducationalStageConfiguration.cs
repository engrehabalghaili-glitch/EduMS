using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EducationalStageConfiguration : IEntityTypeConfiguration<EducationalStage>
{
    public void Configure(EntityTypeBuilder<EducationalStage> builder)
    {
        // Table Name
        builder.ToTable("educational_stage");

        // Property Configurations
        builder.Property(x => x.StageCode)
               .HasMaxLength(100);

        builder.Property(x => x.StageNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.StageNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.MinistryCurriculumCode)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
