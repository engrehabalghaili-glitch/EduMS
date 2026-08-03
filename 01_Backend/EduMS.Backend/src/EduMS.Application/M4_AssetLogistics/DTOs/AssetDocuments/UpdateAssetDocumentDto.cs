using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetDocuments;

public class UpdateAssetDocumentDto
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
}
