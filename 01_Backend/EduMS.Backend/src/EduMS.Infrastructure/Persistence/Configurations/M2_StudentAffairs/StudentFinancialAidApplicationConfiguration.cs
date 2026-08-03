using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentFinancialAidApplicationConfiguration : IEntityTypeConfiguration<StudentFinancialAidApplication>
{
    public void Configure(EntityTypeBuilder<StudentFinancialAidApplication> builder)
    {
        // Table Name
        builder.ToTable("student_financial_aid_application");

        // Property Configurations
        builder.Property(x => x.ApplicationReferenceNumber)
               .HasMaxLength(100);

        builder.Property(x => x.RequestedAidAmountOrPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.VerifiedGuardianAnnualIncome)
               .HasPrecision(18, 2);

        builder.Property(x => x.ApprovedDiscountPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.IncomeProofAttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.CommitteeDecisionRemarks)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
