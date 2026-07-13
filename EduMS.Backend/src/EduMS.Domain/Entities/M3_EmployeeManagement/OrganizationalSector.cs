using System;
using System.Collections.Generic;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// القطاع التنظيمي / وحدة العمل - Universal Organizational Sector/Unit (M3).
/// Decouples Employee from a strict School context, enabling universal HR management across
/// regional directorates (مكاتب الإدارة والتعليم), localized schools (المدرسة), central ministry departments (الوزارة),
/// guidance centers (مراكز التوجيه), and operational depots (المستودعات).
/// </summary>
public class OrganizationalSector : BaseAuditableEntity
{
    public string SectorCode { get; set; } = string.Empty;
    public string SectorNameAr { get; set; } = string.Empty;
    public string? SectorNameEn { get; set; }
    
    /// <summary>
    /// 1=CentralMinistry, 2=RegionalDirectorate, 3=LocalSchool, 4=GuidanceCenter, 5=LogisticsDepot, 6=ExaminationCenter, 7=AdministrativeOffice
    /// </summary>
    public int SectorType { get; set; } = 3;
    
    public long? ParentSectorId { get; set; }
    public long? DirectorateId { get; set; }
    public long? SchoolId { get; set; }
    public string? CostCenterCode { get; set; }
    public decimal AnnualHrBudget { get; set; }
    public long? HeadOfSectorEmployeeId { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual OrganizationalSector? ParentSector { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual School? School { get; set; }
    public virtual Employee? HeadOfSectorEmployee { get; set; }

    // Child Navigation Collections
    public virtual ICollection<OrganizationalSector> SubSectors { get; set; } = new List<OrganizationalSector>();
    public virtual ICollection<Employee> AssignedEmployees { get; set; } = new List<Employee>();
}
