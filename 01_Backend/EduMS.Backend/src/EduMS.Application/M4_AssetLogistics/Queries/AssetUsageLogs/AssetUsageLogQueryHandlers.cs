using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetUsageLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetUsageLogs;

public class AssetUsageLogQueryHandlers : 
    IRequestHandler<GetAssetUsageLogByIdQuery, AssetUsageLogDto>,
    IRequestHandler<GetAllAssetUsageLogsQuery, IEnumerable<AssetUsageLogDto>>
{
    private readonly IGenericRepository<AssetUsageLog> _repository;
    private readonly IMapper _mapper;

    public AssetUsageLogQueryHandlers(IGenericRepository<AssetUsageLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetUsageLogDto> Handle(GetAssetUsageLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetUsageLog not found.");
        return _mapper.Map<AssetUsageLogDto>(entity);
    }

    public async Task<IEnumerable<AssetUsageLogDto>> Handle(GetAllAssetUsageLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetUsageLogDto>>(entities);
    }
}