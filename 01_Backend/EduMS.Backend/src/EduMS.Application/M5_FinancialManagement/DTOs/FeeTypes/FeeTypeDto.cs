using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.FeeTypes;

public class FeeTypeDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public long? GradeCapacityId { get; set; }
    public string FeeCode { get; set; } = string.Empty;
    public string FeeNameAr { get; set; } = string.Empty;
    public string? FeeNameEn { get; set; }
    public int FeeCategory { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "SAR";
    public string BillingFrequency { get; set; } = "Annual";
    public bool IsTaxable { get; set; }
    public decimal TaxPercentage { get; set; } = 15m;
    public bool IsMandatory { get; set; }
    public bool IsOptional { get; set; }
    public bool IsDiscountable { get; set; }
    public decimal? DiscountPercentageAllowed { get; set; }
    public bool IsRefundable { get; set; }
    public decimal? RefundPercentage { get; set; }
    public DateTime? RefundCutoffDate { get; set; }
    public bool IsRecurring { get; set; }
    public string? RecurrenceType { get; set; }
    public string? AppliesToGradesJson { get; set; }
    public string? AppliesToNationalitiesJson { get; set; }
    public string? AppliesToStudentTypesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string? DescriptionAr { get; set; }
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
