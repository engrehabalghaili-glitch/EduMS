using EduMS.Application.M4_AssetLogistics.DTOs.AssetTechnicalSpecifications;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetTechnicalSpecifications;

public class GetAssetTechnicalSpecificationByIdQuery : IRequest<AssetTechnicalSpecificationDto>
{
    public long Id { get; set; }
}

public class GetAllAssetTechnicalSpecificationsQuery : IRequest<IEnumerable<AssetTechnicalSpecificationDto>>
{
}