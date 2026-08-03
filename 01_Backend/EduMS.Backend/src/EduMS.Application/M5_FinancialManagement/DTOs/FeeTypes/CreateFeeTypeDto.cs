using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.FeeTypes;

public class CreateFeeTypeDto
{
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
}
