using EduMS.Application.M4_AssetLogistics.DTOs.DepreciationTransactions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.DepreciationTransactions;

public class GetDepreciationTransactionByIdQuery : IRequest<DepreciationTransactionDto>
{
    public long Id { get; set; }
}

public class GetAllDepreciationTransactionsQuery : IRequest<IEnumerable<DepreciationTransactionDto>>
{
}