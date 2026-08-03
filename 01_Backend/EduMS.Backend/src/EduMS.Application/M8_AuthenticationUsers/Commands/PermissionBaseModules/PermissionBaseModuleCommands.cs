using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionBaseModules;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.PermissionBaseModules;

public class CreatePermissionBaseModuleCommand : IRequest<long>
{
    public CreatePermissionBaseModuleDto Dto { get; set; } = new();
}

public class UpdatePermissionBaseModuleCommand : IRequest<bool>
{
    public UpdatePermissionBaseModuleDto Dto { get; set; } = new();
}

public class DeletePermissionBaseModuleCommand : IRequest<bool>
{
    public long Id { get; set; }
}