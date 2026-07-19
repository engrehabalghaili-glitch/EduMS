using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentBasePermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentBasePermissions;

public class CreateStudentBasePermissionCommand : IRequest<long>
{
    public CreateStudentBasePermissionDto Dto { get; set; } = new();
}

public class UpdateStudentBasePermissionCommand : IRequest<bool>
{
    public UpdateStudentBasePermissionDto Dto { get; set; } = new();
}

public class DeleteStudentBasePermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}