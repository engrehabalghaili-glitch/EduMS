using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentFinancePermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentFinancePermissions;

public class CreateStudentFinancePermissionCommand : IRequest<long>
{
    public CreateStudentFinancePermissionDto Dto { get; set; } = new();
}

public class UpdateStudentFinancePermissionCommand : IRequest<bool>
{
    public UpdateStudentFinancePermissionDto Dto { get; set; } = new();
}

public class DeleteStudentFinancePermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}