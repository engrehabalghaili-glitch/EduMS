using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoans;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetLoans;

public class GetAssetLoanByIdQuery : IRequest<AssetLoanDto>
{
    public long Id { get; set; }
}

public class GetAllAssetLoansQuery : IRequest<IEnumerable<AssetLoanDto>>
{
}