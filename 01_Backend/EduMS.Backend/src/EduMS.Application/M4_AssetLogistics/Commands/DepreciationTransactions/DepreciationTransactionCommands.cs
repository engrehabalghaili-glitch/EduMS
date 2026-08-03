using EduMS.Application.M4_AssetLogistics.DTOs.DepreciationTransactions;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.DepreciationTransactions;

public class CreateDepreciationTransactionCommand : IRequest<long>
{
    public CreateDepreciationTransactionDto Dto { get; set; } = new();
}

public class UpdateDepreciationTransactionCommand : IRequest<bool>
{
    public UpdateDepreciationTransactionDto Dto { get; set; } = new();
}

public class DeleteDepreciationTransactionCommand : IRequest<bool>
{
    public long Id { get; set; }
}