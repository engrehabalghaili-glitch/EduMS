using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.ReferenceCodingLookups;

public class CreateReferenceCodingLookupDto
{
    public long? SchoolId { get; set; }
    public string CodeType { get; set; }
    public string CodeKey { get; set; }
    public string CodeValueAr { get; set; }
    public string? CodeValueEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public int SortOrder { get; set; }
    public bool IsSystemCode { get; set; }
    public long? ParentCodeId { get; set; }
    public string? Notes { get; set; }
}
