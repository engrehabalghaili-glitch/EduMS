using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissions;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissions;

public class CreateBehaviorPermissionCommand : IRequest<long>
{
    public CreateBehaviorPermissionDto Dto { get; set; } = new();
}

public class UpdateBehaviorPermissionCommand : IRequest<bool>
{
    public UpdateBehaviorPermissionDto Dto { get; set; } = new();
}

public class DeleteBehaviorPermissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}