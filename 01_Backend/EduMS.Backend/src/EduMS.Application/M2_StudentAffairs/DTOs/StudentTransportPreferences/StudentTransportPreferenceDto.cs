using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportPreferences;

public class StudentTransportPreferenceDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int TransportType { get; set; }
    public long? PreferredBusRouteId { get; set; }
    public string? PickupAddress { get; set; }
    public string? PickupGpsLatitude { get; set; }
    public string? PickupGpsLongitude { get; set; }
    public string? PreferredPickupTime { get; set; }
    public string? PreferredDropoffTime { get; set; }
    public bool UseMorningPickup { get; set; }
    public bool UseAfternoonDropoff { get; set; }
    public string? WeeklyDaysJson { get; set; }
    public bool RequiresEscort { get; set; }
    public string? EscortName { get; set; }
    public string? EscortPhone { get; set; }
    public string? EscortRelationToStudent { get; set; }
    public bool RequiresSpecialNeedsTransport { get; set; }
    public string? SpecialNeedsTransportDetails { get; set; }
    public bool IsWheelchairAccessibleBusRequired { get; set; }
    public int SubscriptionStatus { get; set; }
    public DateTime? SubscriptionStartDate { get; set; }
    public DateTime? SubscriptionEndDate { get; set; }
    public decimal SubscriptionFeeAmount { get; set; }
    public bool IsTransportContractSigned { get; set; }
    public string? TransportContractFileUrl { get; set; }
    public string? AuthorizedPickupPersonsJson { get; set; }

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
