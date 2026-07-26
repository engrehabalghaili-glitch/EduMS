using EduMS.Application.M8_AuthenticationUsers.DTOs.PrivilegeRules;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.PrivilegeRules;

public class CreatePrivilegeRuleCommand : IRequest<long>
{
    public CreatePrivilegeRuleDto Dto { get; set; } = new();
}

public class UpdatePrivilegeRuleCommand : IRequest<bool>
{
    public UpdatePrivilegeRuleDto Dto { get; set; } = new();
}

public class DeletePrivilegeRuleCommand : IRequest<bool>
{
    public long Id { get; set; }
}