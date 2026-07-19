using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionBaseModules;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.PermissionBaseModules;

public class GetPermissionBaseModuleByIdQuery : IRequest<PermissionBaseModuleDto>
{
    public long Id { get; set; }
}

public class GetAllPermissionBaseModulesQuery : IRequest<IEnumerable<PermissionBaseModuleDto>>
{
}