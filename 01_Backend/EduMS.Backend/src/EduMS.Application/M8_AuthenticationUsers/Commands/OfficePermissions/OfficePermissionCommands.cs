using EduMS.Application.M8_AuthenticationUsers.DTOs.OfficePermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.OfficePermissions;

public class CreateOfficePermissionCommand : IRequest<long>
{
    public CreateOfficePermissionDto Dto { get; set; } = new();
}

public class UpdateOfficePermissionCommand : IRequest<bool>
{
    public UpdateOfficePermissionDto Dto { get; set; } = new();
}

public class DeleteOfficePermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}