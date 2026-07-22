using EduMS.Application.M8_AuthenticationUsers.DTOs.UserDirectPermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.UserDirectPermissions;

public class CreateUserDirectPermissionCommand : IRequest<long>
{
    public CreateUserDirectPermissionDto Dto { get; set; } = new();
}

public class UpdateUserDirectPermissionCommand : IRequest<bool>
{
    public UpdateUserDirectPermissionDto Dto { get; set; } = new();
}

public class DeleteUserDirectPermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}