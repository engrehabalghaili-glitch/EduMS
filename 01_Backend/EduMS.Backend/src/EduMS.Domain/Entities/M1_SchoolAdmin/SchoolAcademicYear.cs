using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الأعوام الدراسية للمدرسة - Academic year lifecycle management extracted from ZIP ERD source (SchoolAcademicYear table, lines 165-191).
/// </summary>
public class SchoolAcademicYear : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string YearCode { get; set; } = string.Empty;     // e.g. "2024-2025" or "1447H"
    public string YearNameAr { get; set; } = string.Empty;
    public string? YearNameEn { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime RegistrationStartDate { get; set; }
    public DateTime RegistrationEndDate { get; set; }
    public DateTime? AddDropStartDate { get; set; }
    public DateTime? AddDropEndDate { get; set; }
    public DateTime? ExamsStartDate { get; set; }
    public DateTime? ExamsEndDate { get; set; }
    public bool IsCurrentYear { get; set; }
    public int YearStatus { get; set; } = 1; // 1=Open, 2=Closed, 3=Archived
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDate { get; set; }
    public long? PreviousAcademicYearId { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
}
