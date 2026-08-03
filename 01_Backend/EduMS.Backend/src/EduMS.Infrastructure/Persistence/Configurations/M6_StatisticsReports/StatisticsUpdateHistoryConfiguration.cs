using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StatisticsUpdateHistoryConfiguration : IEntityTypeConfiguration<StatisticsUpdateHistory>
{
    public void Configure(EntityTypeBuilder<StatisticsUpdateHistory> builder)
    {
        // Table Name
        builder.ToTable("STATISTICS_UPDATE_HISTORY");

        // Property Configurations
        builder.Property(x => x.ChangeType)
               .HasMaxLength(100);

        builder.Property(x => x.ChangeCategory)
               .HasMaxLength(100);

        builder.Property(x => x.OldValue)
               .HasMaxLength(100);

        builder.Property(x => x.NewValue)
               .HasMaxLength(100);

        builder.Property(x => x.UpdateReason)
               .HasMaxLength(500);

        builder.Property(x => x.SupportingDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


