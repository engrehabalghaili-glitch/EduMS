using EduMS.Application.M4_AssetLogistics.DTOs.AssetExpenses;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetExpenses;

public class CreateAssetExpenseCommand : IRequest<long>
{
    public CreateAssetExpenseDto Dto { get; set; } = new();
}

public class UpdateAssetExpenseCommand : IRequest<bool>
{
    public UpdateAssetExpenseDto Dto { get; set; } = new();
}

public class DeleteAssetExpenseCommand : IRequest<bool>
{
    public long Id { get; set; }
}