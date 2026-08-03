using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SchoolShiftConfiguration : IEntityTypeConfiguration<SchoolShift>
{
    public void Configure(EntityTypeBuilder<SchoolShift> builder)
    {
        // Table Name
        builder.ToTable("school_shift");

        // Property Configurations
        builder.Property(x => x.ShiftNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ShiftNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.StartTime)
               .HasMaxLength(100);

        builder.Property(x => x.EndTime)
               .HasMaxLength(100);

        builder.Property(x => x.ShiftCode)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
