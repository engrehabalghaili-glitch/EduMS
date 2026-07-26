using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityComparisons;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFeasibilityComparisons;

public class AssetFeasibilityComparisonQueryHandlers : 
    IRequestHandler<GetAssetFeasibilityComparisonByIdQuery, AssetFeasibilityComparisonDto>,
    IRequestHandler<GetAllAssetFeasibilityComparisonsQuery, IEnumerable<AssetFeasibilityComparisonDto>>
{
    private readonly IGenericRepository<AssetFeasibilityComparison> _repository;
    private readonly IMapper _mapper;

    public AssetFeasibilityComparisonQueryHandlers(IGenericRepository<AssetFeasibilityComparison> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetFeasibilityComparisonDto> Handle(GetAssetFeasibilityComparisonByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetFeasibilityComparison not found.");
        return _mapper.Map<AssetFeasibilityComparisonDto>(entity);
    }

    public async Task<IEnumerable<AssetFeasibilityComparisonDto>> Handle(GetAllAssetFeasibilityComparisonsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetFeasibilityComparisonDto>>(entities);
    }
}