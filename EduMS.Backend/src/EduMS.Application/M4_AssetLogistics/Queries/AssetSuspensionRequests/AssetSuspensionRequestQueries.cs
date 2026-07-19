using EduMS.Application.M4_AssetLogistics.DTOs.AssetSuspensionRequests;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetSuspensionRequests;

public class GetAssetSuspensionRequestByIdQuery : IRequest<AssetSuspensionRequestDto>
{
    public long Id { get; set; }
}

public class GetAllAssetSuspensionRequestsQuery : IRequest<IEnumerable<AssetSuspensionRequestDto>>
{
}