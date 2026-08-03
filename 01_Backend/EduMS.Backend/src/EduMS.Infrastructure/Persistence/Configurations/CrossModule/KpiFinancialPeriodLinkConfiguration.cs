using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class KpiFinancialPeriodLinkConfiguration : IEntityTypeConfiguration<KpiFinancialPeriodLink>
{
    public void Configure(EntityTypeBuilder<KpiFinancialPeriodLink> builder)
    {
        // Table Name
        builder.ToTable("kpi_financial_period_link");

        // Property Configurations
        builder.Property(x => x.PeriodLabel)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
