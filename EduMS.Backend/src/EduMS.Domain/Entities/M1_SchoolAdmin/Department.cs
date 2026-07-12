using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Department : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string DepartmentCode { get; set; } = string.Empty;
    public string DepartmentNameAr { get; set; } = string.Empty;
    public string DepartmentNameEn { get; set; } = string.Empty;
    public int DepartmentType { get; set; } // 1=Academic, 2=Administrative, 3=Financial
    public string? Responsibilities { get; set; }
    public decimal AnnualBudget { get; set; }
    public int EmployeeCount { get; set; }
    public long? HeadOfDepartmentEmployeeId { get; set; }
    public string? WorkingHoursDescription { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Property
    public virtual School? School { get; set; }
}
