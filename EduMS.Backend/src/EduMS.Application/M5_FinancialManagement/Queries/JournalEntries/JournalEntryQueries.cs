using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntries;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.JournalEntries;

public class GetJournalEntryByIdQuery : IRequest<JournalEntryDto>
{
    public long Id { get; set; }
}

public class GetAllJournalEntriesQuery : IRequest<IEnumerable<JournalEntryDto>>
{
}