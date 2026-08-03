using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class BehavioralLogConfiguration : IEntityTypeConfiguration<BehavioralLog>
{
    public void Configure(EntityTypeBuilder<BehavioralLog> builder)
    {
        // Table Name
        builder.ToTable("behavioral_log");

        // Property Configurations
        builder.Property(x => x.IncidentTitleAr)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.ActionTaken)
               .HasMaxLength(100);

        builder.Property(x => x.IncidentTitleEn)
               .HasMaxLength(100);

        builder.Property(x => x.IncidentLocation)
               .HasMaxLength(100);

        builder.Property(x => x.InvestigationNotes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
