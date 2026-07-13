using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ReferenceCodingLookups;

public class ReferenceCodingLookupDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public string CodeType { get; set; } = string.Empty;
    public string CodeKey { get; set; } = string.Empty;
    public string CodeValueAr { get; set; } = string.Empty;
    public string? CodeValueEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public int SortOrder { get; set; }
    public bool IsSystemCode { get; set; }
    public bool IsActive { get; set; }
    public long? ParentCodeId { get; set; }
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
