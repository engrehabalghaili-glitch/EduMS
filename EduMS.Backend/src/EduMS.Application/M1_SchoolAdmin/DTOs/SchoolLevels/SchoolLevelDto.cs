using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLevels;

public class SchoolLevelDto
{
    // Base Entity
    public long Id { get; set; }

    // SchoolLevel Properties
    public long SchoolId { get; set; }
    public string LevelNameAr { get; set; } = string.Empty;
    public string? LevelNameEn { get; set; }
    public int LevelOrder { get; set; }
    public string StartGrade { get; set; } = string.Empty;
    public string EndGrade { get; set; } = string.Empty;
    public string? AcademicTrack { get; set; }
    public int MinAgeYears { get; set; }
    public int MaxAgeYears { get; set; }
    public long? DefaultShiftId { get; set; }
    public bool IsActive { get; set; }
    public string? Notes { get; set; }

    // Auditing Fields (From BaseAuditableEntity)
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    
    // Enum Representation as String
    public string SyncStatus { get; set; } = string.Empty;
}
