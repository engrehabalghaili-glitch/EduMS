using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentAccountConfiguration : IEntityTypeConfiguration<StudentAccount>
{
    public void Configure(EntityTypeBuilder<StudentAccount> builder)
    {
        // Table Name
        builder.ToTable("student_account");

        // Property Configurations
        builder.Property(x => x.AccountNumber)
               .HasMaxLength(100);

        builder.Property(x => x.TotalDebit)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalCredit)
               .HasPrecision(18, 2);

        builder.Property(x => x.CurrentBalance)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDues)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalPaid)
               .HasPrecision(18, 2);

        builder.Property(x => x.OutstandingBalance)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalDiscount)
               .HasPrecision(18, 2);

        builder.Property(x => x.TotalExemption)
               .HasPrecision(18, 2);

        builder.Property(x => x.LastPaymentAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.ExemptionPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.ExemptionReason)
               .HasMaxLength(500);

        builder.Property(x => x.ExemptionDocumentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.MinimumPaymentRequired)
               .HasPrecision(18, 2);

        builder.Property(x => x.BlockReason)
               .HasMaxLength(500);

        builder.Property(x => x.PaymentPlan)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
