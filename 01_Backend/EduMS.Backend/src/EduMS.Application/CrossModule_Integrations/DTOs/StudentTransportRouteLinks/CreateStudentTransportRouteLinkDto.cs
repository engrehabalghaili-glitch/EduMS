using System;

namespace EduMS.Application.CrossModule_Integrations.DTOs.StudentTransportRouteLinks;

public class CreateStudentTransportRouteLinkDto
{
    public long StudentTransportationSubscriptionId { get; set; }
    public long TransportationServiceId { get; set; }
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public string? AssignedSeatNumber { get; set; }
    public int SubscriptionStatus { get; set; } = 1;
    public DateTime? EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
    public string? Notes { get; set; }
}
