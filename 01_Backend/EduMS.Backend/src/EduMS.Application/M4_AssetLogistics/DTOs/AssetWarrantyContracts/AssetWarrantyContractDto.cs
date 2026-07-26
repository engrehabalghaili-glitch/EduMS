using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetWarrantyContracts;

public class AssetWarrantyContractDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public int ContractType { get; set; }
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
    public int ContractStatus { get; set; } = 1;
    public int ReminderDaysBeforeExpiry { get; set; } = 30;
    public bool IsAlertEnabled { get; set; } = true;
    public DateTime? LastAlertSentDate { get; set; }
    public string? AttachmentUrl { get; set; }
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
