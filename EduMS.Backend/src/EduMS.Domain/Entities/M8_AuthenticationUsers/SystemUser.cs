namespace EduMS.Domain.Entities;

public class SystemUser : Person
{
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Role { get; set; }
    public bool IsActive { get; set; } = true;
    public long? SchoolId { get; set; } // Reference to School (M1)
    public long? OfficeId { get; set; } // Reference to Office (M1)

    // Cross-Module Navigation Property
    public virtual School? School { get; set; }
}
