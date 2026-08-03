using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyClosures;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyClosures;

public class CreateEmergencyClosureCommand : IRequest<long>
{
    public CreateEmergencyClosureDto Dto { get; set; } = new();
}

public class UpdateEmergencyClosureCommand : IRequest<bool>
{
    public UpdateEmergencyClosureDto Dto { get; set; } = new();
}

public class DeleteEmergencyClosureCommand : IRequest<bool>
{
    public long Id { get; set; }
}