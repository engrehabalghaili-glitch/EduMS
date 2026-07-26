using EduMS.Application.M4_AssetLogistics.DTOs.AssetWarrantyContracts;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetWarrantyContracts;

public class GetAssetWarrantyContractByIdQuery : IRequest<AssetWarrantyContractDto>
{
    public long Id { get; set; }
}

public class GetAllAssetWarrantyContractsQuery : IRequest<IEnumerable<AssetWarrantyContractDto>>
{
}