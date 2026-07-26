using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.JournalEntries;

public class CreateJournalEntryCommandValidator : AbstractValidator<CreateJournalEntryCommand>
{
    public CreateJournalEntryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateJournalEntryCommandValidator : AbstractValidator<UpdateJournalEntryCommand>
{
    public UpdateJournalEntryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteJournalEntryCommandValidator : AbstractValidator<DeleteJournalEntryCommand>
{
    public DeleteJournalEntryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}