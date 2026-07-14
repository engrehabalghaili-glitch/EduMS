using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExemptions;

public class CreateStudentExemptionDto
{
    public long StudentId { get; set; }
    public int ExemptionCategory { get; set; }
    public decimal DiscountPercentage { get; set; }
    public string? ReasonDescription { get; set; }
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ExemptionCode { get; set; }
    public string? SupportingDocumentUrl { get; set; }
    public decimal AnnualMaxDiscountAmount { get; set; }
    public bool IsRenewable { get; set; }
    public bool IsActive { get; set; } = true;
}
