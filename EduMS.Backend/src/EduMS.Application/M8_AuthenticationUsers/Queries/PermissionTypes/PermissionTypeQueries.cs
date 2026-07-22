using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionTypes;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.PermissionTypes;

public class GetPermissionTypeByIdQuery : IRequest<PermissionTypeDto>
{
    public long Id { get; set; }
}

public class GetAllPermissionTypesQuery : IRequest<IEnumerable<PermissionTypeDto>>
{
}