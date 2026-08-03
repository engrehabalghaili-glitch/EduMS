using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.AuditableEntityRegistries;

public class AuditableEntityRegistryDto
{
    public long Id { get; set; }
    public string EntityTypeKey { get; set; } = string.Empty;
    public string SourceModule { get; set; } = string.Empty;
    public string TableNameHint { get; set; } = string.Empty;
    public string EntityNameAr { get; set; } = string.Empty;
    public string? EntityNameEn { get; set; }
    public bool IsSensitive { get; set; }
    public bool RequiresApprovalToModify { get; set; }
    public bool IsActive { get; set; } = true;
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
