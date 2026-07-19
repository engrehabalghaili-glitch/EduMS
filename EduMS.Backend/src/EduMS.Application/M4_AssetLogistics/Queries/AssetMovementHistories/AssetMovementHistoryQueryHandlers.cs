using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetMovementHistories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetMovementHistories;

public class AssetMovementHistoryQueryHandlers : 
    IRequestHandler<GetAssetMovementHistoryByIdQuery, AssetMovementHistoryDto>,
    IRequestHandler<GetAllAssetMovementHistoriesQuery, IEnumerable<AssetMovementHistoryDto>>
{
    private readonly IGenericRepository<AssetMovementHistory> _repository;
    private readonly IMapper _mapper;

    public AssetMovementHistoryQueryHandlers(IGenericRepository<AssetMovementHistory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetMovementHistoryDto> Handle(GetAssetMovementHistoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetMovementHistory not found.");
        return _mapper.Map<AssetMovementHistoryDto>(entity);
    }

    public async Task<IEnumerable<AssetMovementHistoryDto>> Handle(GetAllAssetMovementHistoriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetMovementHistoryDto>>(entities);
    }
}