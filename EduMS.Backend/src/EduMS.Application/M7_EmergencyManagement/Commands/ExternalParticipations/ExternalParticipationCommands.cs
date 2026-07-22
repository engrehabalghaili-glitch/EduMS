using EduMS.Application.M7_EmergencyManagement.DTOs.ExternalParticipations;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.ExternalParticipations;

public class CreateExternalParticipationCommand : IRequest<long>
{
    public CreateExternalParticipationDto Dto { get; set; } = new();
}

public class UpdateExternalParticipationCommand : IRequest<bool>
{
    public UpdateExternalParticipationDto Dto { get; set; } = new();
}

public class DeleteExternalParticipationCommand : IRequest<bool>
{
    public long Id { get; set; }
}