using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;

public class SchoolAcademicYearDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string YearCode { get; set; } = string.Empty;
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
    public int YearStatus { get; set; }
    public bool IsArchived { get; set; }
    public DateTime? ArchivedDate { get; set; }
    public long? PreviousAcademicYearId { get; set; }
    public string? Notes { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
