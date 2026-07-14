using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportationSubscriptions;

public class StudentTransportationSubscriptionDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SchoolTransportationRouteId { get; set; }
    public DateTime SubscriptionStartDate { get; set; }
    public DateTime? SubscriptionEndDate { get; set; }
    public string? PickupStationAddress { get; set; }
    public string? DropoffStationAddress { get; set; }
    public int SubscriptionStatus { get; set; }
    public int SubscriptionType { get; set; }
    public decimal AgreedMonthlyFee { get; set; }
    public string? PickupTime { get; set; }
    public string? DropoffTime { get; set; }
    public int AssignedBusStopOrder { get; set; }

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
