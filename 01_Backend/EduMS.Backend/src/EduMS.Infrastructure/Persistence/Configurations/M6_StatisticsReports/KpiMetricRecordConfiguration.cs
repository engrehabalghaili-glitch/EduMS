using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class KpiMetricRecordConfiguration : IEntityTypeConfiguration<KpiMetricRecord>
{
    public void Configure(EntityTypeBuilder<KpiMetricRecord> builder)
    {
        // Table Name
        builder.ToTable("KPI_METRIC_RECORD");

        // Property Configurations
        builder.Property(x => x.ActualValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.TargetValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.PreviousValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.ChangePercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.StatusColor)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


