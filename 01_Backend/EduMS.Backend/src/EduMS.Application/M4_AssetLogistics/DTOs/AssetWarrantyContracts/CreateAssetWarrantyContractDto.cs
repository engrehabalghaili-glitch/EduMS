using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetWarrantyContracts;

public class CreateAssetWarrantyContractDto
{
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
}
