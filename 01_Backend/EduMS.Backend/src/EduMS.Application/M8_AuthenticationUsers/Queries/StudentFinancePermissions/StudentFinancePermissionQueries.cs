using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentFinancePermissions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentFinancePermissions;

public class GetStudentFinancePermissionByIdQuery : IRequest<StudentFinancePermissionDto>
{
    public long Id { get; set; }
}

public class GetAllStudentFinancePermissionsQuery : IRequest<IEnumerable<StudentFinancePermissionDto>>
{
}