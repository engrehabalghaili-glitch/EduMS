using EduMS.Application.M8_AuthenticationUsers.DTOs.GovernanceRbacRules;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.GovernanceRbacRules;

public class GetGovernanceRbacRuleByIdQuery : IRequest<GovernanceRbacRuleDto>
{
    public long Id { get; set; }
}

public class GetAllGovernanceRbacRulesQuery : IRequest<IEnumerable<GovernanceRbacRuleDto>>
{
}