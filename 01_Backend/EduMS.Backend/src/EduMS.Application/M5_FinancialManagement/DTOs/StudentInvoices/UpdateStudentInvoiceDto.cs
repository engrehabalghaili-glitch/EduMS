using System;

namespace EduMS.Application.M5_FinancialManagement.DTOs.StudentInvoices;

public class UpdateStudentInvoiceDto
{
    public long Id { get; set; }
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public DateTime? IssueDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public int? DiscountReason { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TaxRate { get; set; } = 15m;
    public string? TaxRegistrationNumber { get; set; }
    public decimal NetAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public string InvoiceType { get; set; } = string.Empty;
    public string InvoiceCategory { get; set; } = "Mandatory";
    public int PaymentStatus { get; set; } = 1;
    public int InvoiceStatus { get; set; } = 1;
    public string? PaymentMethod { get; set; }
    public bool IsLate { get; set; }
    public int? LateDays { get; set; }
    public decimal? LateFeePercentage { get; set; }
    public decimal? LateFeeAmount { get; set; }
    public bool InstallmentPlan { get; set; }
    public int? InstallmentCount { get; set; }
    public int? CurrentInstallment { get; set; }
    public bool ParentApprovalRequired { get; set; }
    public int ParentApprovalStatus { get; set; } = 1;
    public DateTime? ParentApprovalDate { get; set; }
    public bool SentToParent { get; set; }
    public DateTime? ParentNotifiedAt { get; set; }
    public string? Notes { get; set; }
}
