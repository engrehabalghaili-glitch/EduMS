using System;

namespace EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeViolations;

public class CreateEmployeeViolationDto
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string ViolationReferenceNumber { get; set; } = string.Empty;
    public DateTime ViolationDate { get; set; }
    public int ViolationCategory { get; set; }
    public string ViolationDescriptionAr { get; set; } = string.Empty;
    public string? SupportingDocumentUrl { get; set; }
    public int SanctionType { get; set; }
    public decimal PenaltyDeductionAmount { get; set; }
    public int ViolationStatus { get; set; } = 1;
    public long? ReportedByEmployeeId { get; set; }
    public long? InvestigatingEmployeeId { get; set; }
    public DateTime? InvestigationDate { get; set; }
    public string? InvestigationNotes { get; set; }
    public string? DecisionText { get; set; }
    public DateTime? DecisionDate { get; set; }
    public bool IsAppealed { get; set; }
    public DateTime? AppealDate { get; set; }
    public string? AppealResult { get; set; }
    public string? Notes { get; set; }
}
