using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// عقد ضمان وصيانة الأصل - Asset warranty/maintenance contract extracted from ZIP ERD AssetWarrantyContract table (lines 6731-6760).
/// </summary>
public class AssetWarrantyContract : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public int ContractType { get; set; } // 1=Warranty, 2=MaintenanceContract, 3=SoftwareLicense, 4=Rental
    public string ContractNumber { get; set; } = string.Empty;
    public string ContractName { get; set; } = string.Empty;
    public string ProviderName { get; set; } = string.Empty;
    public string? ProviderContact { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? CoverageDetailsText { get; set; }
    public decimal ContractValue { get; set; }
    public bool HasRenewalOption { get; set; }
    public string? RenewalTerms { get; set; }
    public bool IsActive { get; set; } = true;
    public int ContractStatus { get; set; } = 1; // 1=Active, 2=Expired, 3=Cancelled, 4=Renewed
    public int ReminderDaysBeforeExpiry { get; set; } = 30;
    public bool IsAlertEnabled { get; set; } = true;
    public DateTime? LastAlertSentDate { get; set; }
    public string? AttachmentUrl { get; set; }
    public string? Notes { get; set; }

    public virtual School? School { get; set; }
}

/// <summary>
/// وثيقة الأصل - Asset document attachment extracted from ZIP ERD AssetDocument table (lines 6762-6783).
/// </summary>
public class AssetDocument : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long? ContractId { get; set; }
    public string DocType { get; set; } = string.Empty; // Invoice, Catalogue, Photo, OwnershipCert, UserManual
    public string DocCode { get; set; } = string.Empty;
    public string DocNameAr { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public string? FileType { get; set; }
    public DateTime? UploadDate { get; set; }
    public long? UploadedByUserId { get; set; }
    public bool IsVerified { get; set; }
    public long? VerifiedByUserId { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}
