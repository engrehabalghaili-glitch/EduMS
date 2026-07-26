using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.VisitorEntryLogs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M1_SchoolAdmin.Queries.VisitorEntryLogs;

public class VisitorEntryLogQueryHandlers : 
    IRequestHandler<GetVisitorEntryLogByIdQuery, VisitorEntryLogDto>,
    IRequestHandler<GetAllVisitorEntryLogsQuery, IEnumerable<VisitorEntryLogDto>>
{
    private readonly IGenericRepository<VisitorEntryLog> _repository;
    private readonly IMapper _mapper;

    public VisitorEntryLogQueryHandlers(IGenericRepository<VisitorEntryLog> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<VisitorEntryLogDto> Handle(GetVisitorEntryLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"VisitorEntryLog not found.");
        return _mapper.Map<VisitorEntryLogDto>(entity);
    }

    public async Task<IEnumerable<VisitorEntryLogDto>> Handle(GetAllVisitorEntryLogsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<VisitorEntryLogDto>>(entities);
    }
}