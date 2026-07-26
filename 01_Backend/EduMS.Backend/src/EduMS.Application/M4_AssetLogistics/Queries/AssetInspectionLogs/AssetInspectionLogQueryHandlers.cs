using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetInspectionLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetInspectionLogs;

public class AssetInspectionLogQueryHandlers : 
    IRequestHandler<GetAssetInspectionLogByIdQuery, AssetInspectionLogDto>,
    IRequestHandler<GetAllAssetInspectionLogsQuery, IEnumerable<AssetInspectionLogDto>>
{
    private readonly IGenericRepository<AssetInspectionLog> _repository;
    private readonly IMapper _mapper;

    public AssetInspectionLogQueryHandlers(IGenericRepository<AssetInspectionLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetInspectionLogDto> Handle(GetAssetInspectionLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetInspectionLog not found.");
        return _mapper.Map<AssetInspectionLogDto>(entity);
    }

    public async Task<IEnumerable<AssetInspectionLogDto>> Handle(GetAllAssetInspectionLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetInspectionLogDto>>(entities);
    }
}