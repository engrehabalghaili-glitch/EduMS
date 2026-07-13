using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;

public class EducationalStageDto
{
    // Base Entity
    public long Id { get; set; }

    // EducationalStage Properties
    public string StageCode { get; set; } = string.Empty;
    public string StageNameAr { get; set; } = string.Empty;
    public string StageNameEn { get; set; } = string.Empty;
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public int DefaultDurationYears { get; set; }
    public string? MinistryCurriculumCode { get; set; }
    public bool RequiresGraduationCertificate { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }

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
