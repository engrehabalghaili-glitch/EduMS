using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class School : BaseAuditableEntity
{
    public string SchoolNameAr { get; set; } = string.Empty;
    public string SchoolNameEn { get; set; } = string.Empty;
    public string SchoolCode { get; set; } = string.Empty; // Unique identifier code
    public string Directorate { get; set; } = string.Empty; // Educational directorate
    public string Governorate { get; set; } = string.Empty; // Governorate
    public bool IsActive { get; set; } = true;
}
