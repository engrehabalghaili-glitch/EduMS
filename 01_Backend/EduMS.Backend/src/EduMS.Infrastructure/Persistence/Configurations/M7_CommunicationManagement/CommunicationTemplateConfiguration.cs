using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class CommunicationTemplateConfiguration : IEntityTypeConfiguration<CommunicationTemplate>
{
    public void Configure(EntityTypeBuilder<CommunicationTemplate> builder)
    {
        // Table Name
        builder.ToTable("communication_template");

        // Property Configurations
        builder.Property(x => x.TemplateCode)
               .HasMaxLength(100);

        builder.Property(x => x.TemplateName)
               .HasMaxLength(100);

        builder.Property(x => x.SubjectTemplate)
               .HasMaxLength(100);

        builder.Property(x => x.BodyTemplate)
               .HasMaxLength(100);

        builder.Property(x => x.Type)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
