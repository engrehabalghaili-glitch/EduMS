using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class StudentInventoryCustodyConfiguration : IEntityTypeConfiguration<StudentInventoryCustody>
{
    public void Configure(EntityTypeBuilder<StudentInventoryCustody> builder)
    {
        // Table Name
        builder.ToTable("student_inventory_custody");

        // Property Configurations
        builder.Property(x => x.ItemCode)
               .HasMaxLength(100);

        builder.Property(x => x.ItemNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ItemNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.ConditionNotes)
               .HasMaxLength(500);

        builder.Property(x => x.ReceivedByName)
               .HasMaxLength(100);

        builder.Property(x => x.ReturnNotes)
               .HasMaxLength(500);

        builder.Property(x => x.DamageDescription)
               .HasMaxLength(500);

        builder.Property(x => x.PenaltyAmount)
               .HasPrecision(18, 2);

        builder.Property(x => x.ExemptionReason)
               .HasMaxLength(500);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
