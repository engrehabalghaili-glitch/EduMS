using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class DashboardKpiConfigurationConfiguration : IEntityTypeConfiguration<DashboardKpiConfiguration>
{
    public void Configure(EntityTypeBuilder<DashboardKpiConfiguration> builder)
    {
        // Table Name
        builder.ToTable("DASHBOARD_KPI_CONFIG");

        // Property Configurations
        builder.Property(x => x.KpiCode)
               .HasMaxLength(100);

        builder.Property(x => x.KpiNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.KpiNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.KpiDescription)
               .HasMaxLength(500);

        builder.Property(x => x.SourceModule)
               .HasMaxLength(100);

        builder.Property(x => x.SourceTable)
               .HasMaxLength(100);

        builder.Property(x => x.SourceField)
               .HasMaxLength(100);

        builder.Property(x => x.TargetValue)
               .HasPrecision(18, 2);

        builder.Property(x => x.ThresholdGreen)
               .HasPrecision(18, 2);

        builder.Property(x => x.ThresholdYellow)
               .HasPrecision(18, 2);

        builder.Property(x => x.ThresholdRed)
               .HasPrecision(18, 2);

        builder.Property(x => x.AlertRecipientsJson)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


