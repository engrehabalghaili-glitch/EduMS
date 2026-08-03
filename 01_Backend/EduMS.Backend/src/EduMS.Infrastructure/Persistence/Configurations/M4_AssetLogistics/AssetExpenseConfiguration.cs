using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetExpenseConfiguration : IEntityTypeConfiguration<AssetExpense>
{
    public void Configure(EntityTypeBuilder<AssetExpense> builder)
    {
        // Table Name
        builder.ToTable("asset_expense");

        // Property Configurations
        builder.Property(x => x.Amount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Currency)
               .HasMaxLength(100);

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
