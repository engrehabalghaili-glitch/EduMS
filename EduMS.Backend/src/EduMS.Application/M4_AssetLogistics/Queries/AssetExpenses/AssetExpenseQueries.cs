using EduMS.Application.M4_AssetLogistics.DTOs.AssetExpenses;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetExpenses;

public class GetAssetExpenseByIdQuery : IRequest<AssetExpenseDto>
{
    public long Id { get; set; }
}

public class GetAllAssetExpensesQuery : IRequest<IEnumerable<AssetExpenseDto>>
{
}