using EduMS.Application.M4_AssetLogistics.DTOs.AssetCategories;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetCategories;

public class GetAssetCategoryByIdQuery : IRequest<AssetCategoryDto>
{
    public long Id { get; set; }
}

public class GetAllAssetCategoriesQuery : IRequest<IEnumerable<AssetCategoryDto>>
{
}