using EduMS.Application.M8_AuthenticationUsers.DTOs.OfficePermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.OfficePermissions;

public class GetOfficePermissionByIdQuery : IRequest<OfficePermissionDto>
{
    public long Id { get; set; }
}

public class GetAllOfficePermissionsQuery : IRequest<IEnumerable<OfficePermissionDto>>
{
}