using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissions;

public class GetBehaviorPermissionByIdQuery : IRequest<BehaviorPermissionDto>
{
    public long Id { get; set; }
}

public class GetAllBehaviorPermissionsQuery : IRequest<IEnumerable<BehaviorPermissionDto>>
{
}