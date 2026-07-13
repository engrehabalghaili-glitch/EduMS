using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// مخالفات ومخالفات الموظفين - Employee violations/disciplinary records extracted from ZIP ERD EmployeeViolations table.
/// </summary>
public class EmployeeViolation : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string ViolationReferenceNumber { get; set; } = string.Empty;
    public DateTime ViolationDate { get; set; }
    public int ViolationCategory { get; set; } // 1=Attendance, 2=Conduct, 3=Performance, 4=Policy, 5=Financial
    public string ViolationDescriptionAr { get; set; } = string.Empty;
    public string? SupportingDocumentUrl { get; set; }
    public int SanctionType { get; set; } // 1=Warning, 2=FinalWarning, 3=SalaryDeduction, 4=Suspension, 5=Termination
    public decimal PenaltyDeductionAmount { get; set; }
    public int ViolationStatus { get; set; } = 1; // 1=UnderInvestigation, 2=SanctionIssued, 3=Appealed, 4=Closed
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

    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}
