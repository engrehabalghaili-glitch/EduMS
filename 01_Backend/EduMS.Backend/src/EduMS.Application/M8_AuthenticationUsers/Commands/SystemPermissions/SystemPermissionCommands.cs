using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemPermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemPermissions;

public class CreateSystemPermissionCommand : IRequest<long>
{
    public CreateSystemPermissionDto Dto { get; set; } = new();
}

public class UpdateSystemPermissionCommand : IRequest<bool>
{
    public UpdateSystemPermissionDto Dto { get; set; } = new();
}

public class DeleteSystemPermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}