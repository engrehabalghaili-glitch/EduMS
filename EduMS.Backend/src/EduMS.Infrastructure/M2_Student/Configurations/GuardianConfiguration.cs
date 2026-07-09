using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M2_Student.Configurations;

public class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
{
    public void Configure(EntityTypeBuilder<Guardian> builder)
    {
        builder.ToTable("GUARDIAN");

        builder.Property(g => g.FamilyNumber)
            .HasColumnName("FAMILY_NUMBER")
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(g => g.RelationshipType)
            .HasColumnName("RELATIONSHIP_TYPE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(g => g.JobTitle)
            .HasColumnName("JOB_TITLE")
            .HasMaxLength(100);
    }
}
