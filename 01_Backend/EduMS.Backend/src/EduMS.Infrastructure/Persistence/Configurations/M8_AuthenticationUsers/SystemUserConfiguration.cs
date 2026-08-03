using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduMS.Domain.Entities;

namespace EduMS.Infrastructure.Persistence.Configurations;

public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
{
    public void Configure(EntityTypeBuilder<SystemUser> builder)
    {
        // Table Name
        builder.ToTable("system_user");

        // Property Configurations
        builder.Property(x => x.Username)
               .HasMaxLength(100);

        builder.Property(x => x.PasswordHash)
               .HasMaxLength(100);

        builder.Property(x => x.PasswordSalt)
               .HasMaxLength(100);

        builder.Property(x => x.LockReason)
               .HasMaxLength(500);

        builder.Property(x => x.DeactivationReason)
               .HasMaxLength(500);

        builder.Property(x => x.FullNameAr)
               .HasMaxLength(100);

        builder.Property(x => x.FullNameEn)
               .HasMaxLength(100);

        builder.Property(x => x.NationalId)
               .HasMaxLength(100);

        builder.Property(x => x.Email)
               .HasMaxLength(100);

        builder.Property(x => x.Phone)
               .HasMaxLength(100);

        builder.Property(x => x.TwoFactorSecret)
               .HasMaxLength(100);

        builder.Property(x => x.TwoFactorBackupCodesJson)
               .HasMaxLength(100);

        builder.Property(x => x.LastLoginIp)
               .HasMaxLength(100);

        builder.Property(x => x.LastLoginDevice)
               .HasMaxLength(100);

        builder.Property(x => x.LastLoginUserAgent)
               .HasMaxLength(100);

        builder.Property(x => x.PreferredLanguage)
               .HasMaxLength(100);

        builder.Property(x => x.Timezone)
               .HasMaxLength(100);

        builder.Property(x => x.DateFormat)
               .HasMaxLength(100);

        builder.Property(x => x.Theme)
               .HasMaxLength(100);

        builder.Property(x => x.ProfilePictureUrl)
               .HasMaxLength(100);

        builder.Property(x => x.SignatureImageUrl)
               .HasMaxLength(100);

        builder.Property(x => x.NotificationPreferencesJson)
               .HasMaxLength(100);

        builder.Property(x => x.DashboardLayoutJson)
               .HasMaxLength(100);

        builder.Property(x => x.Notes)
               .HasMaxLength(500);

        builder.Property(x => x.RefreshToken)
               .HasMaxLength(100);

        // Relationships (Explicitly defined per Oracle best practices)
        // TODO: Map foreign keys carefully if needed, though EF Core conventions handle most standard naming.

    }
}
