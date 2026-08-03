using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyHostings;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyHostings;

public class CreateEmergencyHostingCommand : IRequest<long>
{
    public CreateEmergencyHostingDto Dto { get; set; } = new();
}

public class UpdateEmergencyHostingCommand : IRequest<bool>
{
    public UpdateEmergencyHostingDto Dto { get; set; } = new();
}

public class DeleteEmergencyHostingCommand : IRequest<bool>
{
    public long Id { get; set; }
}