using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetCategories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetCategories;

public class AssetCategoryQueryHandlers : 
    IRequestHandler<GetAssetCategoryByIdQuery, AssetCategoryDto>,
    IRequestHandler<GetAllAssetCategoriesQuery, IEnumerable<AssetCategoryDto>>
{
    private readonly IGenericRepository<AssetCategory> _repository;
    private readonly IMapper _mapper;

    public AssetCategoryQueryHandlers(IGenericRepository<AssetCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetCategoryDto> Handle(GetAssetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetCategory not found.");
        return _mapper.Map<AssetCategoryDto>(entity);
    }

    public async Task<IEnumerable<AssetCategoryDto>> Handle(GetAllAssetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetCategoryDto>>(entities);
    }
}