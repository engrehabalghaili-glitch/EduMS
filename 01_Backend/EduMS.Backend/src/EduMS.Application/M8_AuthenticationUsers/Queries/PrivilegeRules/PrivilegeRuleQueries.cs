using EduMS.Application.M8_AuthenticationUsers.DTOs.PrivilegeRules;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.PrivilegeRules;

public class GetPrivilegeRuleByIdQuery : IRequest<PrivilegeRuleDto>
{
    public long Id { get; set; }
}

public class GetAllPrivilegeRulesQuery : IRequest<IEnumerable<PrivilegeRuleDto>>
{
}