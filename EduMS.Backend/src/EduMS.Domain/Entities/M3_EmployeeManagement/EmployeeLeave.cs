using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// إجازات الموظفين - Employee leave management extracted from ZIP ERD EmployeeLeave table.
/// </summary>
public class EmployeeLeave : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int LeaveType { get; set; } // 1=Annual, 2=Sick, 3=Emergency, 4=Maternity, 5=Unpaid, 6=Study
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalDays { get; set; }
    public string LeaveReason { get; set; } = string.Empty;
    public string? SupportingDocumentUrl { get; set; }
    public int ApprovalStatus { get; set; } = 1; // 1=Pending, 2=Approved, 3=Rejected, 4=Cancelled
    public long? ApprovedByEmployeeId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? RejectionReason { get; set; }
    public bool IsEmergency { get; set; }
    public string? ReplacementEmployeeName { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}
