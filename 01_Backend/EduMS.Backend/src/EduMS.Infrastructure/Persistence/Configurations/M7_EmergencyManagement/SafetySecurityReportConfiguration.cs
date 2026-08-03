using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SafetySecurityReportConfiguration : IEntityTypeConfiguration<SafetySecurityReport>
{
    public void Configure(EntityTypeBuilder<SafetySecurityReport> builder)
    {
        // Table Name
        builder.ToTable("safety_security_report");

        // Property Configurations
        builder.Property(x => x.ReportNumber)
               .HasMaxLength(100);

        builder.Property(x => x.ReportPeriod)
               .HasMaxLength(100);

        builder.Property(x => x.SafetyLevel)
               .HasMaxLength(100);

        builder.Property(x => x.AlarmSystemStatus)
               .HasMaxLength(100);

        builder.Property(x => x.EmergencyExitsStatus)
               .HasMaxLength(100);

        builder.Property(x => x.DrillDatesJson)
               .HasMaxLength(100);

        builder.Property(x => x.DrillEvaluation)
               .HasMaxLength(100);

        builder.Property(x => x.SafetyCommitteeMembersJson)
               .HasMaxLength(100);

        builder.Property(x => x.Recommendations)
               .HasMaxLength(100);

        builder.Property(x => x.ActionPlan)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
