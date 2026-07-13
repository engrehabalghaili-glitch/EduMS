using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Directorate : BaseAuditableEntity
{
    public string DirectorateCode { get; set; } = string.Empty;
    public string DirectorateNameAr { get; set; } = string.Empty;
    public string DirectorateNameEn { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? DirectorName { get; set; }
    public string? Governorate { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public string? RegionCode { get; set; }
    public string? SupervisoryScopeDescription { get; set; }
    public decimal AnnualBudgetLimit { get; set; }
    public int EmployeeCount { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Collections
    public virtual ICollection<School> Schools { get; set; } = new List<School>();
    public virtual ICollection<EducationalSupervisionVisit> SupervisionVisits { get; set; } = new List<EducationalSupervisionVisit>();
    public virtual ICollection<SchoolOperationalBudgetLog> OperationalBudgetLogs { get; set; } = new List<SchoolOperationalBudgetLog>();
    public virtual ICollection<TrainingCourseOffering> TrainingCourseOfferings { get; set; } = new List<TrainingCourseOffering>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<OrganizationalSector> OrganizationalSectors { get; set; } = new List<OrganizationalSector>();
}
