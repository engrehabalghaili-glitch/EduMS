using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Person : BaseAuditableEntity
{
    public string FullNameAr { get; set; } = string.Empty;
    public string FullNameEn { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public int Gender { get; set; } // 1 = Male, 2 = Female
    public string? ContactNumber { get; set; }
    public string? MedicalInfo { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? NationalityCode { get; set; }
    public string? EmailAddress { get; set; }
    public string? BloodGroup { get; set; }
    public string? ResidentialAddress { get; set; }
    public string? PassportNumber { get; set; }
    public bool IsActivePerson { get; set; } = true;
}
