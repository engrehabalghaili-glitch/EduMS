using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.FieldInventoryLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.FieldInventoryLogs;

public class FieldInventoryLogQueryHandlers : 
    IRequestHandler<GetFieldInventoryLogByIdQuery, FieldInventoryLogDto>,
    IRequestHandler<GetAllFieldInventoryLogsQuery, IEnumerable<FieldInventoryLogDto>>
{
    private readonly IGenericRepository<FieldInventoryLog> _repository;
    private readonly IMapper _mapper;

    public FieldInventoryLogQueryHandlers(IGenericRepository<FieldInventoryLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FieldInventoryLogDto> Handle(GetFieldInventoryLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FieldInventoryLog not found.");
        return _mapper.Map<FieldInventoryLogDto>(entity);
    }

    public async Task<IEnumerable<FieldInventoryLogDto>> Handle(GetAllFieldInventoryLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FieldInventoryLogDto>>(entities);
    }
}