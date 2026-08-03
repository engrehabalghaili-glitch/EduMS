using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetAllocations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetAllocations;

public class AssetAllocationQueryHandlers : 
    IRequestHandler<GetAssetAllocationByIdQuery, AssetAllocationDto>,
    IRequestHandler<GetAllAssetAllocationsQuery, IEnumerable<AssetAllocationDto>>
{
    private readonly IGenericRepository<AssetAllocation> _repository;
    private readonly IMapper _mapper;

    public AssetAllocationQueryHandlers(IGenericRepository<AssetAllocation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetAllocationDto> Handle(GetAssetAllocationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetAllocation not found.");
        return _mapper.Map<AssetAllocationDto>(entity);
    }

    public async Task<IEnumerable<AssetAllocationDto>> Handle(GetAllAssetAllocationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetAllocationDto>>(entities);
    }
}