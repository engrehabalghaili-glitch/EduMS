using EduMS.Application.M8_AuthenticationUsers.DTOs.UserDirectPermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.UserDirectPermissions;

public class GetUserDirectPermissionByIdQuery : IRequest<UserDirectPermissionDto>
{
    public long Id { get; set; }
}

public class GetAllUserDirectPermissionsQuery : IRequest<IEnumerable<UserDirectPermissionDto>>
{
}