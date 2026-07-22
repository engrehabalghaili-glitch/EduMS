using EduMS.Application.M8_AuthenticationUsers.DTOs.AccessPolicies;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.AccessPolicies;

public class GetAccessPolicyByIdQuery : IRequest<AccessPolicyDto>
{
    public long Id { get; set; }
}

public class GetAllAccessPoliciesQuery : IRequest<IEnumerable<AccessPolicyDto>>
{
}