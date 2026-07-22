using EduMS.Application.M8_AuthenticationUsers.DTOs.AccessPolicies;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.AccessPolicies;

public class CreateAccessPolicyCommand : IRequest<long>
{
    public CreateAccessPolicyDto Dto { get; set; } = new();
}

public class UpdateAccessPolicyCommand : IRequest<bool>
{
    public UpdateAccessPolicyDto Dto { get; set; } = new();
}

public class DeleteAccessPolicyCommand : IRequest<bool>
{
    public long Id { get; set; }
}