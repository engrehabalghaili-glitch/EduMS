using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemUsers;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemUsers;

public class CreateSystemUserCommand : IRequest<long>
{
    public CreateSystemUserDto Dto { get; set; } = new();
}

public class UpdateSystemUserCommand : IRequest<bool>
{
    public UpdateSystemUserDto Dto { get; set; } = new();
}

public class DeleteSystemUserCommand : IRequest<bool>
{
    public long Id { get; set; }
}