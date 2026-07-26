using EduMS.Application.M5_FinancialManagement.DTOs.JournalEntries;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.JournalEntries;

public class CreateJournalEntryCommand : IRequest<long>
{
    public CreateJournalEntryDto Dto { get; set; } = new();
}

public class UpdateJournalEntryCommand : IRequest<bool>
{
    public UpdateJournalEntryDto Dto { get; set; } = new();
}

public class DeleteJournalEntryCommand : IRequest<bool>
{
    public long Id { get; set; }
}