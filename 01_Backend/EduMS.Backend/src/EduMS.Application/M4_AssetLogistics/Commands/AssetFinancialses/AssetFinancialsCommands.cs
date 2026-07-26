using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialses;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialses;

public class CreateAssetFinancialsCommand : IRequest<long>
{
    public CreateAssetFinancialsDto Dto { get; set; } = new();
}

public class UpdateAssetFinancialsCommand : IRequest<bool>
{
    public UpdateAssetFinancialsDto Dto { get; set; } = new();
}

public class DeleteAssetFinancialsCommand : IRequest<bool>
{
    public long Id { get; set; }
}