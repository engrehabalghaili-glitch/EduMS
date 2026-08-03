using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.StudentCustodyAssetLinks;

public class CreateStudentCustodyAssetLinkDto
{
    public long StudentInventoryCustodyId { get; set; }
    public long? SchoolAssetId { get; set; }
    public long? InventoryItemId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public decimal ReplacementValue { get; set; }
    public bool IsReturned { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int ConditionOnReturn { get; set; }
    public string? Notes { get; set; }
}
