using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.GradingScaleBounds;

public class GradingScaleBoundDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string ScaleName { get; set; } = string.Empty;
    public string LetterCode { get; set; } = string.Empty;
    public decimal MinPercentage { get; set; }
    public decimal MaxPercentage { get; set; }
    public decimal GradePointValue { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ScaleCode { get; set; }
    public bool IsPassingGrade { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }

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
