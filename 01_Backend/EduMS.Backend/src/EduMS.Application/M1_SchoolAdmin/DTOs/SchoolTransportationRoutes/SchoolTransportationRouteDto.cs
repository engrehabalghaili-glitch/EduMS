using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.SchoolTransportationRoutes;

public class SchoolTransportationRouteDto
{
    public long Id { get; set; }
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
    public bool IsActive { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
