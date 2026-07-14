using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolTransportationRoutes;

public class CreateSchoolTransportationRouteDto
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
}
