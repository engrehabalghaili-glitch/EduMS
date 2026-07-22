using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionRecords;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissionRecords;

public class BehaviorPermissionRecordQueryHandlers : 
    IRequestHandler<GetBehaviorPermissionRecordByIdQuery, BehaviorPermissionRecordDto>,
    IRequestHandler<GetAllBehaviorPermissionRecordsQuery, IEnumerable<BehaviorPermissionRecordDto>>
{
    private readonly IGenericRepository<BehaviorPermissionRecord> _repository;
    private readonly IMapper _mapper;

    public BehaviorPermissionRecordQueryHandlers(IGenericRepository<BehaviorPermissionRecord> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BehaviorPermissionRecordDto> Handle(GetBehaviorPermissionRecordByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"BehaviorPermissionRecord not found.");
        return _mapper.Map<BehaviorPermissionRecordDto>(entity);
    }

    public async Task<IEnumerable<BehaviorPermissionRecordDto>> Handle(GetAllBehaviorPermissionRecordsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BehaviorPermissionRecordDto>>(entities);
    }
}