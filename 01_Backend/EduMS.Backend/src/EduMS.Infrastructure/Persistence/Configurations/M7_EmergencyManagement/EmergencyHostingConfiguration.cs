using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class EmergencyHostingConfiguration : IEntityTypeConfiguration<EmergencyHosting>
{
    public void Configure(EntityTypeBuilder<EmergencyHosting> builder)
    {
        // Table Name
        builder.ToTable("emergency_hosting");

        // Property Configurations
        builder.Property(x => x.HostingNumber)
               .HasMaxLength(100);

        builder.Property(x => x.HostingType)
               .HasMaxLength(100);

        builder.Property(x => x.UtilizationPercentage)
               .HasPrecision(18, 2);

        builder.Property(x => x.Reason)
               .HasMaxLength(500);

        builder.Property(x => x.SourceLocation)
               .HasMaxLength(100);

        builder.Property(x => x.SupportOrganization)
               .HasMaxLength(100);

        builder.Property(x => x.SupportOrgContact)
               .HasMaxLength(100);

        builder.Property(x => x.FacilitiesUsedJson)
               .HasMaxLength(100);

        builder.Property(x => x.ResourcesProvidedJson)
               .HasMaxLength(100);

        builder.Property(x => x.ResourcesReceivedJson)
               .HasMaxLength(100);

        builder.Property(x => x.ExpensesJson)
               .HasMaxLength(100);

        builder.Property(x => x.TotalExpenses)
               .HasPrecision(18, 2);

        builder.Property(x => x.ClosureNotes)
               .HasMaxLength(500);

        builder.Property(x => x.LessonsLearned)
               .HasMaxLength(100);

        builder.Property(x => x.AttachmentsJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
