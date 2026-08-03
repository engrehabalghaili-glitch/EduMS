using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetStatusRecords;

public class UpdateAssetStatusRecordDto
{
    public long Id { get; set; }
    public long? SchoolId { get; set; }
    public string StatusCode { get; set; } = string.Empty;
    public string StatusNameAr { get; set; } = string.Empty;
    public string? StatusNameEn { get; set; }
    public int StatusType { get; set; }
    public bool IsOperational { get; set; }
    public bool IsAvailableForAssignment { get; set; }
    public bool RequiresApprovalToEnter { get; set; }
    public string? ColorCode { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsSystemStatus { get; set; }
    public int SortOrder { get; set; }
    public string? DescriptionAr { get; set; }
}
