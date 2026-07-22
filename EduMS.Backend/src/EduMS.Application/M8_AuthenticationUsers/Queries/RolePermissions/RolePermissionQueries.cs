using EduMS.Application.M8_AuthenticationUsers.DTOs.RolePermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.RolePermissions;

public class GetRolePermissionByIdQuery : IRequest<RolePermissionDto>
{
    public long Id { get; set; }
}

public class GetAllRolePermissionsQuery : IRequest<IEnumerable<RolePermissionDto>>
{
}