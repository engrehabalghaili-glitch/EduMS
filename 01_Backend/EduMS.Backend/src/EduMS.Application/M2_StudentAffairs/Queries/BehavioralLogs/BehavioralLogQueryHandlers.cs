using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M2_StudentAffairs.DTOs.BehavioralLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M2_StudentAffairs.Queries.BehavioralLogs;

public class BehavioralLogQueryHandlers : 
    IRequestHandler<GetBehavioralLogByIdQuery, BehavioralLogDto>,
    IRequestHandler<GetAllBehavioralLogsQuery, IEnumerable<BehavioralLogDto>>
{
    private readonly IGenericRepository<BehavioralLog> _repository;
    private readonly IMapper _mapper;

    public BehavioralLogQueryHandlers(IGenericRepository<BehavioralLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BehavioralLogDto> Handle(GetBehavioralLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"BehavioralLog not found.");
        return _mapper.Map<BehavioralLogDto>(entity);
    }

    public async Task<IEnumerable<BehavioralLogDto>> Handle(GetAllBehavioralLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BehavioralLogDto>>(entities);
    }
}