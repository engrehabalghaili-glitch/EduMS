using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetBudgetAllocations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetBudgetAllocations;

public class AssetBudgetAllocationQueryHandlers : 
    IRequestHandler<GetAssetBudgetAllocationByIdQuery, AssetBudgetAllocationDto>,
    IRequestHandler<GetAllAssetBudgetAllocationsQuery, IEnumerable<AssetBudgetAllocationDto>>
{
    private readonly IGenericRepository<AssetBudgetAllocation> _repository;
    private readonly IMapper _mapper;

    public AssetBudgetAllocationQueryHandlers(IGenericRepository<AssetBudgetAllocation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetBudgetAllocationDto> Handle(GetAssetBudgetAllocationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetBudgetAllocation not found.");
        return _mapper.Map<AssetBudgetAllocationDto>(entity);
    }

    public async Task<IEnumerable<AssetBudgetAllocationDto>> Handle(GetAllAssetBudgetAllocationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetBudgetAllocationDto>>(entities);
    }
}