using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetLocationRecords;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetLocationRecords;

public class AssetLocationRecordQueryHandlers : 
    IRequestHandler<GetAssetLocationRecordByIdQuery, AssetLocationRecordDto>,
    IRequestHandler<GetAllAssetLocationRecordsQuery, IEnumerable<AssetLocationRecordDto>>
{
    private readonly IGenericRepository<AssetLocationRecord> _repository;
    private readonly IMapper _mapper;

    public AssetLocationRecordQueryHandlers(IGenericRepository<AssetLocationRecord> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetLocationRecordDto> Handle(GetAssetLocationRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetLocationRecord not found.");
        return _mapper.Map<AssetLocationRecordDto>(entity);
    }

    public async Task<IEnumerable<AssetLocationRecordDto>> Handle(GetAllAssetLocationRecordsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetLocationRecordDto>>(entities);
    }
}