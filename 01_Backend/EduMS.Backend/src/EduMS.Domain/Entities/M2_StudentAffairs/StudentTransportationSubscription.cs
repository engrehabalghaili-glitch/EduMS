using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentTransportationSubscription : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SchoolTransportationRouteId { get; set; }
    public DateTime SubscriptionStartDate { get; set; }
    public DateTime? SubscriptionEndDate { get; set; }
    public string? PickupStationAddress { get; set; }
    public string? DropoffStationAddress { get; set; }
    public int SubscriptionStatus { get; set; } // 1=Active, 2=Suspended, 3=Cancelled
    public int SubscriptionType { get; set; } = 1; // 1=TwoWay, 2=MorningOnly, 3=EveningOnly
    public decimal AgreedMonthlyFee { get; set; }
    public string? PickupTime { get; set; }
    public string? DropoffTime { get; set; }
    public int AssignedBusStopOrder { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual SchoolTransportationRoute? Route { get; set; }
}
