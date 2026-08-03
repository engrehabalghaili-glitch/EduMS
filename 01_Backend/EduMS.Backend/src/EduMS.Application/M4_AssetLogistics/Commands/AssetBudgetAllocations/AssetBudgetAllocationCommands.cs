using EduMS.Application.M4_AssetLogistics.DTOs.AssetBudgetAllocations;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetBudgetAllocations;

public class CreateAssetBudgetAllocationCommand : IRequest<long>
{
    public CreateAssetBudgetAllocationDto Dto { get; set; } = new();
}

public class UpdateAssetBudgetAllocationCommand : IRequest<bool>
{
    public UpdateAssetBudgetAllocationDto Dto { get; set; } = new();
}

public class DeleteAssetBudgetAllocationCommand : IRequest<bool>
{
    public long Id { get; set; }
}