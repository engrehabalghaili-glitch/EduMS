using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetDocuments;

public class AssetDocumentDto
{
    public long Id { get; set; }
    public long AssetId { get; set; }
    public long? ContractId { get; set; }
    public string DocType { get; set; } = string.Empty;
    public string DocCode { get; set; } = string.Empty;
    public string DocNameAr { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public string? FileType { get; set; }
    public DateTime? UploadDate { get; set; }
    public long? UploadedByUserId { get; set; }
    public bool IsVerified { get; set; }
    public long? VerifiedByUserId { get; set; }
    public DateTime? VerifiedAt { get; set; }
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
