using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// مهام وأعمال إضافية للموظف - Employee additional tasks / extra duties extracted from ZIP ERD EmployeeAdditionalTasks table.
/// </summary>
public class EmployeeAdditionalTask : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public string TaskTitleAr { get; set; } = string.Empty;
    public string? TaskDescription { get; set; }
    public int TaskType { get; set; } // 1=Supervision, 2=CommitteeWork, 3=ExtraTeaching, 4=AdminDuty
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool HasFinancialCompensation { get; set; }
    public decimal CompensationAmount { get; set; }
    public long? AssignedByEmployeeId { get; set; }
    public int TaskStatus { get; set; } = 1; // 1=Active, 2=Completed, 3=Cancelled
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}

/// <summary>
/// المشرف والمرشد الوظيفي للموظف - Mentor assignment extracted from ZIP ERD Mentor table.
/// </summary>
public class EmployeeMentor : BaseAuditableEntity
{
    public long MentorEmployeeId { get; set; }
    public long MenteeEmployeeId { get; set; }
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public DateTime AssignmentDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? MentoringGoals { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    public virtual Employee? Mentor { get; set; }
    public virtual Employee? Mentee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}

/// <summary>
/// طلبات البوابة الإلكترونية للموظف (الخدمة الذاتية) - Self-service portal requests extracted from ZIP ERD SelfServicePortalRequests table.
/// </summary>
public class SelfServicePortalRequest : BaseAuditableEntity
{
    public long EmployeeId { get; set; }
    public int RequestType { get; set; } // 1=LeaveRequest, 2=DocumentRequest, 3=PayslipRequest, 4=DataUpdateRequest
    public string RequestTitleAr { get; set; } = string.Empty;
    public string? RequestDetailsText { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
    public int RequestStatus { get; set; } = 1; // 1=Submitted, 2=UnderReview, 3=Approved, 4=Rejected, 5=Completed
    public long? ReviewedByUserId { get; set; }
    public DateTime? ReviewDate { get; set; }
    public string? RejectionReason { get; set; }
    public string? AttachmentUrl { get; set; }
    public string? Notes { get; set; }

    public virtual Employee? Employee { get; set; }
}
