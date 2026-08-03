using EduMS.Application.M4_AssetLogistics.DTOs.AssetTechnicalSpecifications;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetTechnicalSpecifications;

public class CreateAssetTechnicalSpecificationCommand : IRequest<long>
{
    public CreateAssetTechnicalSpecificationDto Dto { get; set; } = new();
}

public class UpdateAssetTechnicalSpecificationCommand : IRequest<bool>
{
    public UpdateAssetTechnicalSpecificationDto Dto { get; set; } = new();
}

public class DeleteAssetTechnicalSpecificationCommand : IRequest<bool>
{
    public long Id { get; set; }
}