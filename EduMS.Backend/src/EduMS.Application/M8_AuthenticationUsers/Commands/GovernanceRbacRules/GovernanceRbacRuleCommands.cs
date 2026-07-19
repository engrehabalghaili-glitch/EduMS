using EduMS.Application.M8_AuthenticationUsers.DTOs.GovernanceRbacRules;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.GovernanceRbacRules;

public class CreateGovernanceRbacRuleCommand : IRequest<long>
{
    public CreateGovernanceRbacRuleDto Dto { get; set; } = new();
}

public class UpdateGovernanceRbacRuleCommand : IRequest<bool>
{
    public UpdateGovernanceRbacRuleDto Dto { get; set; } = new();
}

public class DeleteGovernanceRbacRuleCommand : IRequest<bool>
{
    public long Id { get; set; }
}