using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// تفضيلات النقل المدرسي للطالب - Detailed transport preference record extracted from ZIP ERD StudentTransportPreference table (lines 2152-2198).
/// Distinct from StudentTransportationSubscription: this captures preferred stops, times, days, escort, and special-needs transport needs.
/// </summary>
public class StudentTransportPreference : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public int TransportType { get; set; } // 1=SchoolBus, 2=PrivateCar, 3=Walking, 4=PublicTransport, 5=Other
    public long? PreferredBusRouteId { get; set; }
    public string? PickupAddress { get; set; }
    public string? PickupGpsLatitude { get; set; }
    public string? PickupGpsLongitude { get; set; }
    public string? PreferredPickupTime { get; set; }
    public string? PreferredDropoffTime { get; set; }
    public bool UseMorningPickup { get; set; } = true;
    public bool UseAfternoonDropoff { get; set; } = true;
    public string? WeeklyDaysJson { get; set; }           // JSON: days needing transport
    public bool RequiresEscort { get; set; }
    public string? EscortName { get; set; }
    public string? EscortPhone { get; set; }
    public string? EscortRelationToStudent { get; set; }
    public bool RequiresSpecialNeedsTransport { get; set; }
    public string? SpecialNeedsTransportDetails { get; set; }
    public bool IsWheelchairAccessibleBusRequired { get; set; }
    public int SubscriptionStatus { get; set; } = 1; // 1=Active, 2=Suspended, 3=Cancelled, 4=Pending
    public DateTime? SubscriptionStartDate { get; set; }
    public DateTime? SubscriptionEndDate { get; set; }
    public decimal SubscriptionFeeAmount { get; set; }
    public bool IsTransportContractSigned { get; set; }
    public string? TransportContractFileUrl { get; set; }
    public string? AuthorizedPickupPersonsJson { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
}
