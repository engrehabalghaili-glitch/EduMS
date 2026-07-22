using EduMS.Application.M7_EmergencyManagement.DTOs.RemediationPlans;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.RemediationPlans;

public class CreateRemediationPlanCommand : IRequest<long>
{
    public CreateRemediationPlanDto Dto { get; set; } = new();
}

public class UpdateRemediationPlanCommand : IRequest<bool>
{
    public UpdateRemediationPlanDto Dto { get; set; } = new();
}

public class DeleteRemediationPlanCommand : IRequest<bool>
{
    public long Id { get; set; }
}