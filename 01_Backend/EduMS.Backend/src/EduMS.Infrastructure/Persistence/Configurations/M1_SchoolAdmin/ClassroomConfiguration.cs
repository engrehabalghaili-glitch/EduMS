using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        // Table Name
        builder.ToTable("classroom");

        // Property Configurations
        builder.Property(x => x.ClassroomCode)
               .HasMaxLength(100);

        builder.Property(x => x.ClassroomNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.ClassroomNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.RoomNumber)
               .HasMaxLength(100);

        builder.Property(x => x.BuildingSection)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
