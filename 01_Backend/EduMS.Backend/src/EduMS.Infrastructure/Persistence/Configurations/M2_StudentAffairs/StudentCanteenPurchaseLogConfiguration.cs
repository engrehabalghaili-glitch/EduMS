using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentCanteenPurchaseLogConfiguration : IEntityTypeConfiguration<StudentCanteenPurchaseLog>
{
    public void Configure(EntityTypeBuilder<StudentCanteenPurchaseLog> builder)
    {
        // Table Name
        builder.ToTable("student_canteen_purchase_log");

        // Property Configurations
        builder.Property(x => x.TotalCost)
               .HasPrecision(18, 2);

        builder.Property(x => x.TransactionReferenceNumber)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
