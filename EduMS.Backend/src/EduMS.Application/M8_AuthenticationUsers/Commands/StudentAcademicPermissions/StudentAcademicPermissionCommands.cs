using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentAcademicPermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentAcademicPermissions;

public class CreateStudentAcademicPermissionCommand : IRequest<long>
{
    public CreateStudentAcademicPermissionDto Dto { get; set; } = new();
}

public class UpdateStudentAcademicPermissionCommand : IRequest<bool>
{
    public UpdateStudentAcademicPermissionDto Dto { get; set; } = new();
}

public class DeleteStudentAcademicPermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}