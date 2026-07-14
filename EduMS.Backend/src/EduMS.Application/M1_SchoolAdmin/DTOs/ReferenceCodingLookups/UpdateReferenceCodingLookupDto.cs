using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ReferenceCodingLookups;

public class UpdateReferenceCodingLookupDto
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
}
