using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
{
    public void Configure(EntityTypeBuilder<Guardian> builder)
    {
        // Table Name
        builder.ToTable("guardian");

        // Property Configurations
        builder.Property(x => x.FamilyNumber)
               .HasMaxLength(100);

        builder.Property(x => x.RelationshipType)
               .HasMaxLength(100);

        builder.Property(x => x.JobTitle)
               .HasMaxLength(100);

        builder.Property(x => x.EmployerName)
               .HasMaxLength(100);

        builder.Property(x => x.WorkPhoneNumber)
               .HasMaxLength(100);

        builder.Property(x => x.PreferredLanguage)
               .HasMaxLength(100);

        builder.Property(x => x.AnnualIncomeRange)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
