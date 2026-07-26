using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionTypes;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.PermissionTypes;

public class CreatePermissionTypeCommand : IRequest<long>
{
    public CreatePermissionTypeDto Dto { get; set; } = new();
}

public class UpdatePermissionTypeCommand : IRequest<bool>
{
    public UpdatePermissionTypeDto Dto { get; set; } = new();
}

public class DeletePermissionTypeCommand : IRequest<bool>
{
    public long Id { get; set; }
}