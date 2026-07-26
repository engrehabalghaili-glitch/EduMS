using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.JournalEntryLines;

public class CreateJournalEntryLineCommandValidator : AbstractValidator<CreateJournalEntryLineCommand>
{
    public CreateJournalEntryLineCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateJournalEntryLineCommandValidator : AbstractValidator<UpdateJournalEntryLineCommand>
{
    public UpdateJournalEntryLineCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteJournalEntryLineCommandValidator : AbstractValidator<DeleteJournalEntryLineCommand>
{
    public DeleteJournalEntryLineCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}