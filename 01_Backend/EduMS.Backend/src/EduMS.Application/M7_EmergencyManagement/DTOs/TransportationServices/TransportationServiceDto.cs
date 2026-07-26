using System;

namespace EduMS.Application.M7_EmergencyManagement.DTOs.TransportationServices;

public class TransportationServiceDto
{
    public long Id { get; set; }
    public long SchoolId { get; set; }
    public string RouteCode { get; set; } = string.Empty;
    public string RouteName { get; set; } = string.Empty;
    public string? RouteDescription { get; set; }
    public long? BusAssetId { get; set; }
    public string? BusPlateNumber { get; set; }
    public int? BusCapacity { get; set; }
    public string? BusModel { get; set; }
    public string? BusYear { get; set; }
    public long? DriverEmployeeId { get; set; }
    public string? DriverLicenseNumber { get; set; }
    public string? DriverPhone { get; set; }
    public long? SupervisorEmployeeId { get; set; }
    public string? SupervisorPhone { get; set; }
    public long? ShiftId { get; set; }
    public int TripType { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? EstimatedDurationMinutes { get; set; }
    public string? StopsJson { get; set; }
    public bool IsActive { get; set; } = true;
    public int ServiceStatus { get; set; } = 1;
    public string? OperatorCompany { get; set; }
    public long? ContractId { get; set; }
    public string? Notes { get; set; }
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
