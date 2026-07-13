using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
{
    public void Configure(EntityTypeBuilder<Classroom> builder)
    {
        builder.ToTable("CLASSROOM");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.ClassroomCode)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(c => c.ClassroomNameAr)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.ClassroomNameEn)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(c => new { c.SchoolId, c.ClassroomCode })
            .IsUnique();

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(c => c.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
