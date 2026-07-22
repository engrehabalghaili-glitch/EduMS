using EduMS.Application.M4_AssetLogistics.DTOs.AssetTransferRequests;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetTransferRequests;

public class GetAssetTransferRequestByIdQuery : IRequest<AssetTransferRequestDto>
{
    public long Id { get; set; }
}

public class GetAllAssetTransferRequestsQuery : IRequest<IEnumerable<AssetTransferRequestDto>>
{
}