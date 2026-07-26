using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyIncidents;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyIncidents;

public class GetEmergencyIncidentByIdQuery : IRequest<EmergencyIncidentDto>
{
    public long Id { get; set; }
}

public class GetAllEmergencyIncidentsQuery : IRequest<IEnumerable<EmergencyIncidentDto>>
{
}