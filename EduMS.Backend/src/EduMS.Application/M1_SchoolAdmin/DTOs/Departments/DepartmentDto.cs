using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.Departments;

public class DepartmentDto
{
    // Base Entity
    public long Id { get; set; }

    // Department Properties
    public long SchoolId { get; set; }
    public string DepartmentCode { get; set; } = string.Empty;
    public string DepartmentNameAr { get; set; } = string.Empty;
    public string DepartmentNameEn { get; set; } = string.Empty;
    public int DepartmentType { get; set; }
    public string? Responsibilities { get; set; }
    public decimal AnnualBudget { get; set; }
    public int EmployeeCount { get; set; }
    public long? HeadOfDepartmentEmployeeId { get; set; }
    public string? WorkingHoursDescription { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public bool IsActive { get; set; }

    // Auditing Fields (From BaseAuditableEntity)
    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    
    // Enum Representation as String
    public string SyncStatus { get; set; } = string.Empty;
}
