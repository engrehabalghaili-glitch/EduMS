using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentBasePermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentBasePermissions;

public class GetStudentBasePermissionByIdQuery : IRequest<StudentBasePermissionDto>
{
    public long Id { get; set; }
}

public class GetAllStudentBasePermissionsQuery : IRequest<IEnumerable<StudentBasePermissionDto>>
{
}