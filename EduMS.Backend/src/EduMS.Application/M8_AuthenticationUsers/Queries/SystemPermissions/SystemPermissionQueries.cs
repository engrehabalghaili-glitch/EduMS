using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemPermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemPermissions;

public class GetSystemPermissionByIdQuery : IRequest<SystemPermissionDto>
{
    public long Id { get; set; }
}

public class GetAllSystemPermissionsQuery : IRequest<IEnumerable<SystemPermissionDto>>
{
}