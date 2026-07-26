using EduMS.Application.M4_AssetLogistics.DTOs.AssetCategories;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetCategories;

public class CreateAssetCategoryCommand : IRequest<long>
{
    public CreateAssetCategoryDto Dto { get; set; } = new();
}

public class UpdateAssetCategoryCommand : IRequest<bool>
{
    public UpdateAssetCategoryDto Dto { get; set; } = new();
}

public class DeleteAssetCategoryCommand : IRequest<bool>
{
    public long Id { get; set; }
}