using EduMS.Application.M8_AuthenticationUsers.DTOs.RolePermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.RolePermissions;

public class CreateRolePermissionCommand : IRequest<long>
{
    public CreateRolePermissionDto Dto { get; set; } = new();
}

public class UpdateRolePermissionCommand : IRequest<bool>
{
    public UpdateRolePermissionDto Dto { get; set; } = new();
}

public class DeleteRolePermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}