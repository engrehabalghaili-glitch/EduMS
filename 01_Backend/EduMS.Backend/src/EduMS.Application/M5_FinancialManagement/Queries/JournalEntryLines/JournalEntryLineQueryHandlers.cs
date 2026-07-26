using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntryLines;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.JournalEntryLines;

public class JournalEntryLineQueryHandlers : 
    IRequestHandler<GetJournalEntryLineByIdQuery, JournalEntryLineDto>,
    IRequestHandler<GetAllJournalEntryLinesQuery, IEnumerable<JournalEntryLineDto>>
{
    private readonly IGenericRepository<JournalEntryLine> _repository;
    private readonly IMapper _mapper;

    public JournalEntryLineQueryHandlers(IGenericRepository<JournalEntryLine> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JournalEntryLineDto> Handle(GetJournalEntryLineByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"JournalEntryLine not found.");
        return _mapper.Map<JournalEntryLineDto>(entity);
    }

    public async Task<IEnumerable<JournalEntryLineDto>> Handle(GetAllJournalEntryLinesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<JournalEntryLineDto>>(entities);
    }
}