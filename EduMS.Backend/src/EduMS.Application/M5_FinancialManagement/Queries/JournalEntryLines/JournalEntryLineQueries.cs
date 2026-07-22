using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntryLines;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.JournalEntryLines;

public class GetJournalEntryLineByIdQuery : IRequest<JournalEntryLineDto>
{
    public long Id { get; set; }
}

public class GetAllJournalEntryLinesQuery : IRequest<IEnumerable<JournalEntryLineDto>>
{
}