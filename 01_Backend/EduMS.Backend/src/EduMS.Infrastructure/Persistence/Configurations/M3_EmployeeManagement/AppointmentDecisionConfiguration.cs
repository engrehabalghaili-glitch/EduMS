using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AppointmentDecisionConfiguration : IEntityTypeConfiguration<AppointmentDecision>
{
    public void Configure(EntityTypeBuilder<AppointmentDecision> builder)
    {
        // Table Name
        builder.ToTable("appointment_decision");

        // Property Configurations
        builder.Property(x => x.DecisionNumber)
               .HasMaxLength(100);

        builder.Property(x => x.JobTitle)
               .HasMaxLength(100);

        builder.Property(x => x.JobGrade)
               .HasMaxLength(100);

        builder.Property(x => x.SalaryAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.AllowanceDetailsJson)
               .HasMaxLength(100);

        builder.Property(x => x.OtherBenefits)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentUrl)
               .HasMaxLength(100);

        builder.Property(x => x.ApprovedByName)
               .HasMaxLength(100);

        builder.Property(x => x.ApprovedByTitle)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
