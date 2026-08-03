using EduMS.Application.M4_AssetLogistics.DTOs.AssetWarrantyContracts;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetWarrantyContracts;

public class CreateAssetWarrantyContractCommand : IRequest<long>
{
    public CreateAssetWarrantyContractDto Dto { get; set; } = new();
}

public class UpdateAssetWarrantyContractCommand : IRequest<bool>
{
    public UpdateAssetWarrantyContractDto Dto { get; set; } = new();
}

public class DeleteAssetWarrantyContractCommand : IRequest<bool>
{
    public long Id { get; set; }
}