using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// مستخدم النظام - Full system user entity extracted from ZIP ERD SystemUser (lines 8440-8496).
/// Central authentication and identity entity; linked to Employee/Student/Guardian via FK.
/// </summary>
public class SystemUser : BaseAuditableEntity
{
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
    public int UserType { get; set; } // 1=SysAdmin, 2=SchoolPrincipal, 3=VicePrincipal, 4=Teacher, 5=Student, 6=Guardian, 7=OfficeManager
    public long? EmployeeId { get; set; }
    public long? StudentId { get; set; }
    public long? GuardianId { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public int TwoFactorMethod { get; set; } // 1=Email, 2=SMS, 3=AuthApp
    public string? TwoFactorSecret { get; set; }
    public string? TwoFactorBackupCodesJson { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public string? LastLoginIp { get; set; }
    public string? LastLoginDevice { get; set; }
    public string? LastLoginUserAgent { get; set; }
    public DateTime? PreviousLoginDate { get; set; }
    public string? PreferredLanguage { get; set; } // ar, en
    public string? Timezone { get; set; }
    public string? DateFormat { get; set; } // DD/MM/YYYY
    public string? Theme { get; set; } // light, dark
    public string? ProfilePictureUrl { get; set; }
    public string? SignatureImageUrl { get; set; }
    public string? NotificationPreferencesJson { get; set; }
    public string? DashboardLayoutJson { get; set; }
    public string? Notes { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual Student? Student { get; set; }
    public virtual ICollection<UserRoleAssignment> UserRoleAssignments { get; set; } = new List<UserRoleAssignment>();
}




