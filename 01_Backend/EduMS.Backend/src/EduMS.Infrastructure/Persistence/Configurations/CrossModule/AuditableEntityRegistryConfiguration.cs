using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AuditableEntityRegistryConfiguration : IEntityTypeConfiguration<AuditableEntityRegistry>
{
    public void Configure(EntityTypeBuilder<AuditableEntityRegistry> builder)
    {
        // Table Name
        builder.ToTable("auditable_entity_registry");

        // Property Configurations
        builder.Property(x => x.EntityTypeKey)
               .HasMaxLength(100);

        builder.Property(x => x.SourceModule)
               .HasMaxLength(100);

        builder.Property(x => x.TableNameHint)
               .HasMaxLength(100);

        builder.Property(x => x.EntityNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.EntityNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
