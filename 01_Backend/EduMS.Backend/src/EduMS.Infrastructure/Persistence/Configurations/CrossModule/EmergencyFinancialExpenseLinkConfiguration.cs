using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyFinancialExpenseLinkConfiguration : IEntityTypeConfiguration<EmergencyFinancialExpenseLink>
{
    public void Configure(EntityTypeBuilder<EmergencyFinancialExpenseLink> builder)
    {
        // Table Name
        builder.ToTable("emergency_financial_expense_link");

        // Property Configurations
        builder.Property(x => x.ExpenseAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.ExpenseCategory)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
