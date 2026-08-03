using System;

namespace EduMS.Application.M4_AssetLogistics.DTOs.AssetLocationRecords;

public class CreateAssetLocationRecordDto
{
    public long SchoolId { get; set; }
    public long? ParentLocationId { get; set; }
    public string LocationCode { get; set; } = string.Empty;
    public string LocationNameAr { get; set; } = string.Empty;
    public string? LocationNameEn { get; set; }
    public int LocationType { get; set; }
    public string? BuildingName { get; set; }
    public int? FloorNumber { get; set; }
    public string? RoomNumber { get; set; }
    public bool IsActive { get; set; } = true;
    public long? ResponsiblePersonId { get; set; }
    public string? MapReference { get; set; }
    public string? QrCode { get; set; }
    public string? Notes { get; set; }
}
