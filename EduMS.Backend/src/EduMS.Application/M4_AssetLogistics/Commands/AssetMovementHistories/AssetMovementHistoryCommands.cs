using EduMS.Application.M4_AssetLogistics.DTOs.AssetMovementHistories;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetMovementHistories;

public class CreateAssetMovementHistoryCommand : IRequest<long>
{
    public CreateAssetMovementHistoryDto Dto { get; set; } = new();
}

public class UpdateAssetMovementHistoryCommand : IRequest<bool>
{
    public UpdateAssetMovementHistoryDto Dto { get; set; } = new();
}

public class DeleteAssetMovementHistoryCommand : IRequest<bool>
{
    public long Id { get; set; }
}