using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyPlans;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyPlans;

public class CreateEmergencyPlanCommand : IRequest<long>
{
    public CreateEmergencyPlanDto Dto { get; set; } = new();
}

public class UpdateEmergencyPlanCommand : IRequest<bool>
{
    public UpdateEmergencyPlanDto Dto { get; set; } = new();
}

public class DeleteEmergencyPlanCommand : IRequest<bool>
{
    public long Id { get; set; }
}