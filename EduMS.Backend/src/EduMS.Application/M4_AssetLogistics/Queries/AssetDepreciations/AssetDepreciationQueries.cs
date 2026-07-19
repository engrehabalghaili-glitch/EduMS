using EduMS.Application.M4_AssetLogistics.DTOs.AssetDepreciations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetDepreciations;

public class GetAssetDepreciationByIdQuery : IRequest<AssetDepreciationDto>
{
    public long Id { get; set; }
}

public class GetAllAssetDepreciationsQuery : IRequest<IEnumerable<AssetDepreciationDto>>
{
}