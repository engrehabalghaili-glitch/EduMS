using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialses;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialses;

public class GetAssetFinancialsByIdQuery : IRequest<AssetFinancialsDto>
{
    public long Id { get; set; }
}

public class GetAllAssetFinancialsesQuery : IRequest<IEnumerable<AssetFinancialsDto>>
{
}