using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ClassroomResourceAllocationConfiguration : IEntityTypeConfiguration<ClassroomResourceAllocation>
{
    public void Configure(EntityTypeBuilder<ClassroomResourceAllocation> builder)
    {
        // Table Name
        builder.ToTable("classroom_resource_allocation");

        // Property Configurations
        builder.Property(x => x.ResourceNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ResourceCode)
               .HasMaxLength(100);

        builder.Property(x => x.ConditionStatus)
               .HasMaxLength(100);

        builder.Property(x => x.ResourceNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.AssetSerialNumber)
               .HasMaxLength(100);

        builder.Property(x => x.UnitPurchaseCost)
               .HasPrecision(18, 2);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
