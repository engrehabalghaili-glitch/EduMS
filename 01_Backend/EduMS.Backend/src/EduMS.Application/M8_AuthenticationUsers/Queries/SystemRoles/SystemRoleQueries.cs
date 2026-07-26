using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemRoles;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemRoles;

public class GetSystemRoleByIdQuery : IRequest<SystemRoleDto>
{
    public long Id { get; set; }
}

public class GetAllSystemRolesQuery : IRequest<IEnumerable<SystemRoleDto>>
{
}