using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolAnnouncementLogConfiguration : IEntityTypeConfiguration<SchoolAnnouncementLog>
{
    public void Configure(EntityTypeBuilder<SchoolAnnouncementLog> builder)
    {
        // Table Name
        builder.ToTable("school_announcement_log");

        // Property Configurations
        builder.Property(x => x.TitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.TitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.AnnouncementContent)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentFileUrl)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
