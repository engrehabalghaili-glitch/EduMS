using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolAwardConfiguration : IEntityTypeConfiguration<SchoolAward>
{
    public void Configure(EntityTypeBuilder<SchoolAward> builder)
    {
        // Table Name
        builder.ToTable("school_award");

        // Property Configurations
        builder.Property(x => x.AwardNumber)
               .HasMaxLength(100);

        builder.Property(x => x.AwardName)
               .HasMaxLength(100);

        builder.Property(x => x.AwardCategory)
               .HasMaxLength(100);

        builder.Property(x => x.IssuingBody)
               .HasMaxLength(100);

        builder.Property(x => x.IssuingBodyType)
               .HasMaxLength(100);

        builder.Property(x => x.AwardPlace)
               .HasMaxLength(100);

        builder.Property(x => x.Ranking)
               .HasMaxLength(100);

        builder.Property(x => x.ParticipantsJson)
               .HasMaxLength(100);

        builder.Property(x => x.AwardDetails)
               .HasMaxLength(100);

        builder.Property(x => x.CertificatePath)
               .HasMaxLength(100);

        builder.Property(x => x.PhotosPathJson)
               .HasMaxLength(100);

        builder.Property(x => x.VideoPath)
               .HasMaxLength(100);

        builder.Property(x => x.Impact)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
