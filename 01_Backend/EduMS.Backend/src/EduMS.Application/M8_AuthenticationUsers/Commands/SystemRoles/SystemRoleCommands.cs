using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemRoles;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemRoles;

public class CreateSystemRoleCommand : IRequest<long>
{
    public CreateSystemRoleDto Dto { get; set; } = new();
}

public class UpdateSystemRoleCommand : IRequest<bool>
{
    public UpdateSystemRoleDto Dto { get; set; } = new();
}

public class DeleteSystemRoleCommand : IRequest<bool>
{
    public long Id { get; set; }
}