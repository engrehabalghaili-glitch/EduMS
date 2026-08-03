using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolStatisticsDraftConfiguration : IEntityTypeConfiguration<SchoolStatisticsDraft>
{
    public void Configure(EntityTypeBuilder<SchoolStatisticsDraft> builder)
    {
        // Table Name
        builder.ToTable("SCHOOL_STATISTICS_DRAFT");

        // Property Configurations
        builder.Property(x => x.DraftNumber)
               .HasMaxLength(100);

        builder.Property(x => x.DraftVersion)
               .HasMaxLength(100);

        builder.Property(x => x.StudentDataJson)
               .HasMaxLength(100);

        builder.Property(x => x.StaffDataJson)
               .HasMaxLength(100);

        builder.Property(x => x.FinancialSummaryJson)
               .HasMaxLength(100);

        builder.Property(x => x.AssetSummaryJson)
               .HasMaxLength(100);

        builder.Property(x => x.CompletenessPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}


