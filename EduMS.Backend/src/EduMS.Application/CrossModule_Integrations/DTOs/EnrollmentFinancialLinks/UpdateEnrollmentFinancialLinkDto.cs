using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.EnrollmentFinancialLinks;

public class UpdateEnrollmentFinancialLinkDto
{
    public long Id { get; set; }
    public long EnrollmentId { get; set; }
    public long StudentAccountId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public decimal TuitionFeeDue { get; set; }
    public decimal DiscountApplied { get; set; }
    public decimal ExemptionApplied { get; set; }
    public decimal NetPayable { get; set; }
    public bool IsSettled { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? Notes { get; set; }
}
