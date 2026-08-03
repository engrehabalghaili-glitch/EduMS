using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionMatrixes;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissionMatrixes;

public class CreateBehaviorPermissionMatrixCommand : IRequest<long>
{
    public CreateBehaviorPermissionMatrixDto Dto { get; set; } = new();
}

public class UpdateBehaviorPermissionMatrixCommand : IRequest<bool>
{
    public UpdateBehaviorPermissionMatrixDto Dto { get; set; } = new();
}

public class DeleteBehaviorPermissionMatrixCommand : IRequest<bool>
{
    public long Id { get; set; }
}