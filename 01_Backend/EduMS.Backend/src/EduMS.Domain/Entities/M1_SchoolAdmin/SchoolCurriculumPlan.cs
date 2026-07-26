using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الخطط الدراسية المعتمدة للمدرسة - Curriculum plan registry extracted from ZIP ERD SchoolCurriculumPlan table (lines 256-280).
/// Manages ministerially-approved curriculum plans per academic year and grade level.
/// </summary>
public class SchoolCurriculumPlan : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PlanNameAr { get; set; } = string.Empty;
    public string? PlanNameEn { get; set; }
    public string PlanCode { get; set; } = string.Empty;
    public long? GradeCapacityId { get; set; }
    public long? SchoolLevelId { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long? SchoolSemesterId { get; set; }
    public string PlanVersion { get; set; } = "V1.0";
    public DateTime AdoptionDate { get; set; }
    public decimal TotalCreditHours { get; set; }
    public int PlanStatus { get; set; } = 1; // 1=Draft, 2=Approved, 3=Cancelled
    public int MinisterialApprovalStatus { get; set; } = 1; // 1=UnderReview, 2=Approved, 3=Rejected, 4=Deferred
    public string? ApprovalDocumentUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime EffectiveDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual SchoolAcademicYear? AcademicYear { get; set; }
}
