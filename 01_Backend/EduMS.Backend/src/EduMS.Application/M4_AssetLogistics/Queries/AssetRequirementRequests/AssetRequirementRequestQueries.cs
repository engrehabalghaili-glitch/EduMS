using EduMS.Application.M4_AssetLogistics.DTOs.AssetRequirementRequests;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetRequirementRequests;

public class GetAssetRequirementRequestByIdQuery : IRequest<AssetRequirementRequestDto>
{
    public long Id { get; set; }
}

public class GetAllAssetRequirementRequestsQuery : IRequest<IEnumerable<AssetRequirementRequestDto>>
{
}