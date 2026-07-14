using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentTransportationSubscriptions;

public class UpdateStudentTransportationSubscriptionDto
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
}
