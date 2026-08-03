using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionRecords;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissionRecords;

public class CreateBehaviorPermissionRecordCommand : IRequest<long>
{
    public CreateBehaviorPermissionRecordDto Dto { get; set; } = new();
}

public class UpdateBehaviorPermissionRecordCommand : IRequest<bool>
{
    public UpdateBehaviorPermissionRecordDto Dto { get; set; } = new();
}

public class DeleteBehaviorPermissionRecordCommand : IRequest<bool>
{
    public long Id { get; set; }
}