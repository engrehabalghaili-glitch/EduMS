using System;

namespace EduMS.Application.M8_AuthenticationUsers.DTOs.SystemUsers;

public class SystemUserDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public long? OfficeId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? PasswordSalt { get; set; }
    public DateTime? PasswordExpiryDate { get; set; }
    public DateTime? LastPasswordChangeDate { get; set; }
    public bool MustChangePassword { get; set; }
    public int FailedAttempts { get; set; }
    public DateTime? LastFailedAttemptDate { get; set; }
    public bool IsLocked { get; set; }
    public string? LockReason { get; set; }
    public DateTime? LockExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? ActivationDate { get; set; }
    public DateTime? DeactivationDate { get; set; }
    public string? DeactivationReason { get; set; }
    public string FullNameAr { get; set; } = string.Empty;
    public string? FullNameEn { get; set; }
    public string NationalId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool EmailVerified { get; set; }
    public DateTime? EmailVerifiedAt { get; set; }
    public string? Phone { get; set; }
    public bool PhoneVerified { get; set; }
    public DateTime? PhoneVerifiedAt { get; set; }
    public int UserType { get; set; }
    public long? EmployeeId { get; set; }
    public long? StudentId { get; set; }
    public long? GuardianId { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public int TwoFactorMethod { get; set; }
    public string? TwoFactorSecret { get; set; }
    public string? TwoFactorBackupCodesJson { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public string? LastLoginIp { get; set; }
    public string? LastLoginDevice { get; set; }
    public string? LastLoginUserAgent { get; set; }
    public DateTime? PreviousLoginDate { get; set; }
    public string? PreferredLanguage { get; set; }
    public string? Timezone { get; set; }
    public string? DateFormat { get; set; }
    public string? Theme { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? SignatureImageUrl { get; set; }
    public string? NotificationPreferencesJson { get; set; }
    public string? DashboardLayoutJson { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
