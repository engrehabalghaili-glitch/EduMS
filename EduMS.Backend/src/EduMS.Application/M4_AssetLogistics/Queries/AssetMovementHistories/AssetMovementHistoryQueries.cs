using EduMS.Application.M4_AssetLogistics.DTOs.AssetMovementHistories;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetMovementHistories;

public class GetAssetMovementHistoryByIdQuery : IRequest<AssetMovementHistoryDto>
{
    public long Id { get; set; }
}

public class GetAllAssetMovementHistoriesQuery : IRequest<IEnumerable<AssetMovementHistoryDto>>
{
}