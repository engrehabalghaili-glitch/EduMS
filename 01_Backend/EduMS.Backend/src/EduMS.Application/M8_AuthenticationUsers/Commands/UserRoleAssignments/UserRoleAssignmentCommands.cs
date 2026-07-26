using EduMS.Application.M8_AuthenticationUsers.DTOs.UserRoleAssignments;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.UserRoleAssignments;

public class CreateUserRoleAssignmentCommand : IRequest<long>
{
    public CreateUserRoleAssignmentDto Dto { get; set; } = new();
}

public class UpdateUserRoleAssignmentCommand : IRequest<bool>
{
    public UpdateUserRoleAssignmentDto Dto { get; set; } = new();
}

public class DeleteUserRoleAssignmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}