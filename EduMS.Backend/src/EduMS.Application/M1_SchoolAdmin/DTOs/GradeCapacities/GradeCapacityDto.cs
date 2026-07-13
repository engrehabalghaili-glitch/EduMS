using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.GradeCapacities;

public class GradeCapacityDto
{
    public long Id { get; set; }
    public long SchoolAcademicYearId { get; set; }
    public long SchoolLevelId { get; set; }
    public string GradeLevelCode { get; set; } = string.Empty;
    public string GradeNameAr { get; set; } = string.Empty;
    public string? GradeNameEn { get; set; }
    public int MaxStudentsPerSection { get; set; }
    public int MaxSectionsCount { get; set; }
    public int CurrentEnrolledCount { get; set; }
    public int GenderAllocation { get; set; }
    public bool IsActive { get; set; }
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
