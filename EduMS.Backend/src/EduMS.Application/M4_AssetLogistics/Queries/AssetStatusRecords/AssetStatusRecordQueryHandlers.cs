using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.AssetStatusRecords;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetStatusRecords;

public class AssetStatusRecordQueryHandlers : 
    IRequestHandler<GetAssetStatusRecordByIdQuery, AssetStatusRecordDto>,
    IRequestHandler<GetAllAssetStatusRecordsQuery, IEnumerable<AssetStatusRecordDto>>
{
    private readonly IGenericRepository<AssetStatusRecord> _repository;
    private readonly IMapper _mapper;

    public AssetStatusRecordQueryHandlers(IGenericRepository<AssetStatusRecord> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssetStatusRecordDto> Handle(GetAssetStatusRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AssetStatusRecord not found.");
        return _mapper.Map<AssetStatusRecordDto>(entity);
    }

    public async Task<IEnumerable<AssetStatusRecordDto>> Handle(GetAllAssetStatusRecordsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AssetStatusRecordDto>>(entities);
    }
}