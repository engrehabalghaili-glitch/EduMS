using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.FeeInstallments;

public class UpdateFeeInstallmentDto
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public long? ItemId { get; set; }
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int InstallmentNumber { get; set; }
    public int InstallmentTotal { get; set; }
    public decimal InstallmentAmount { get; set; }
    public string Currency { get; set; } = "SAR";
    public DateTime DueDate { get; set; }
    public DateTime? ExtendedDueDate { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
    public string? PaymentReference { get; set; }
    public string? InstallmentType { get; set; }
    public int InstallmentStatus { get; set; } = 1;
    public bool IsLate { get; set; }
    public int? LateDays { get; set; }
    public decimal? LateFeePercentage { get; set; }
    public decimal? LateFeeAmount { get; set; }
    public bool LateFeePaid { get; set; }
    public DateTime? LateFeePaymentDate { get; set; }
    public string? LateFeePaymentReference { get; set; }
    public bool IsRescheduled { get; set; }
    public DateTime? RescheduledDate { get; set; }
    public long? RescheduledByUserId { get; set; }
    public string? RescheduledReason { get; set; }
    public DateTime? NewDueDate { get; set; }
    public bool IsWaived { get; set; }
    public string? WaiverReason { get; set; }
    public DateTime? WaiverDate { get; set; }
    public long? WaivedByUserId { get; set; }
    public string? WaiverApprovalDocumentUrl { get; set; }
    public string? Notes { get; set; }
}
