using EduMS.Application.M8_AuthenticationUsers.DTOs.RoleMatrixes;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.RoleMatrixes;

public class CreateRoleMatrixCommand : IRequest<long>
{
    public CreateRoleMatrixDto Dto { get; set; } = new();
}

public class UpdateRoleMatrixCommand : IRequest<bool>
{
    public UpdateRoleMatrixDto Dto { get; set; } = new();
}

public class DeleteRoleMatrixCommand : IRequest<bool>
{
    public long Id { get; set; }
}