using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class AcademicLockPeriodConfiguration : IEntityTypeConfiguration<AcademicLockPeriod>
{
    public void Configure(EntityTypeBuilder<AcademicLockPeriod> builder)
    {
        // Table Name
        builder.ToTable("academic_lock_period");

        // Property Configurations
        builder.Property(x => x.PeriodName)
               .HasMaxLength(100);

        builder.Property(x => x.UnlockReasonDescription)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
