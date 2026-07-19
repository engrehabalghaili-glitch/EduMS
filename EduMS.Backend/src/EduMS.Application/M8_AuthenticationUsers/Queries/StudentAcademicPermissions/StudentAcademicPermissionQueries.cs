using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentAcademicPermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentAcademicPermissions;

public class GetStudentAcademicPermissionByIdQuery : IRequest<StudentAcademicPermissionDto>
{
    public long Id { get; set; }
}

public class GetAllStudentAcademicPermissionsQuery : IRequest<IEnumerable<StudentAcademicPermissionDto>>
{
}