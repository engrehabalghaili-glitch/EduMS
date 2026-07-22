using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.JournalEntries;

public class JournalEntryQueryHandlers : 
    IRequestHandler<GetJournalEntryByIdQuery, JournalEntryDto>,
    IRequestHandler<GetAllJournalEntriesQuery, IEnumerable<JournalEntryDto>>
{
    private readonly IGenericRepository<JournalEntry> _repository;
    private readonly IMapper _mapper;

    public JournalEntryQueryHandlers(IGenericRepository<JournalEntry> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JournalEntryDto> Handle(GetJournalEntryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"JournalEntry not found.");
        return _mapper.Map<JournalEntryDto>(entity);
    }

    public async Task<IEnumerable<JournalEntryDto>> Handle(GetAllJournalEntriesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<JournalEntryDto>>(entities);
    }
}