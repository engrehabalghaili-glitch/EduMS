using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AssetLoanConfiguration : IEntityTypeConfiguration<AssetLoan>
{
    public void Configure(EntityTypeBuilder<AssetLoan> builder)
    {
        // Table Name
        builder.ToTable("asset_loan");

        // Property Configurations
        builder.Property(x => x.BorrowerName)
               .HasMaxLength(100);

        builder.Property(x => x.BorrowerContact)
               .HasMaxLength(100);

        builder.Property(x => x.LoanPurpose)
               .HasMaxLength(100);

        builder.Property(x => x.FineAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
