using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntryLines;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.JournalEntryLines;

public class CreateJournalEntryLineCommand : IRequest<long>
{
    public CreateJournalEntryLineDto Dto { get; set; } = new();
}

public class UpdateJournalEntryLineCommand : IRequest<bool>
{
    public UpdateJournalEntryLineDto Dto { get; set; } = new();
}

public class DeleteJournalEntryLineCommand : IRequest<bool>
{
    public long Id { get; set; }
}