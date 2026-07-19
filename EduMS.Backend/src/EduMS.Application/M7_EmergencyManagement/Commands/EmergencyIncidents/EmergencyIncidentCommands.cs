using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyIncidents;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyIncidents;

public class CreateEmergencyIncidentCommand : IRequest<long>
{
    public CreateEmergencyIncidentDto Dto { get; set; } = new();
}

public class UpdateEmergencyIncidentCommand : IRequest<bool>
{
    public UpdateEmergencyIncidentDto Dto { get; set; } = new();
}

public class DeleteEmergencyIncidentCommand : IRequest<bool>
{
    public long Id { get; set; }
}