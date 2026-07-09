using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M1_SchoolAdmin.Configurations;

public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
{
    public void Configure(EntityTypeBuilder<SystemUser> builder)
    {
        builder.ToTable("SYSTEM_USER");

        builder.Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasColumnName("PASSWORD_HASH")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasColumnName("ROLE")
            .HasMaxLength(50);

        builder.Property(u => u.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        builder.Property(u => u.SchoolId)
            .HasColumnName("SCHOOL_ID");

        builder.Property(u => u.OfficeId)
            .HasColumnName("OFFICE_ID");
    }
}
