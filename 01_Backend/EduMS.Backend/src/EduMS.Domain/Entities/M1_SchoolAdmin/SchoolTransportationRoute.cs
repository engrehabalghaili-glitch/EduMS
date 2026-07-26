using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class SchoolTransportationRoute : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string RouteCode { get; set; } = string.Empty;
    public string RouteNameAr { get; set; } = string.Empty;
    public long? DriverEmployeeId { get; set; }
    public string? BusPlateNumber { get; set; }
    public int TotalSeats { get; set; }
    public string MorningStartHour { get; set; } = string.Empty;
    public string EveningReturnHour { get; set; } = string.Empty;
    public decimal MonthlyFee { get; set; }
    public string? RouteNameEn { get; set; }
    public long? BusSupervisorEmployeeId { get; set; }
    public string? BusModelAndYear { get; set; }
    public int TotalSubscribedStudents { get; set; }
    public string? GpsTrackingDeviceId { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Employee? DriverEmployee { get; set; }
    public virtual Employee? BusSupervisorEmployee { get; set; }
}
