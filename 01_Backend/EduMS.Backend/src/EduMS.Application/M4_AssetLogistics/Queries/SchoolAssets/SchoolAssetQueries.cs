using EduMS.Application.M4_AssetLogistics.DTOs.SchoolAssets;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.SchoolAssets;

public class GetSchoolAssetByIdQuery : IRequest<SchoolAssetDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolAssetsQuery : IRequest<IEnumerable<SchoolAssetDto>>
{
}