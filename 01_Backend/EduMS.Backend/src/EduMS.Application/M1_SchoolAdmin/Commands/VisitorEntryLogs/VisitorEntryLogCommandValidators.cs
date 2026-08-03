using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.VisitorEntryLogs;

public class CreateVisitorEntryLogCommandValidator : AbstractValidator<CreateVisitorEntryLogCommand>
{
    public CreateVisitorEntryLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateVisitorEntryLogCommandValidator : AbstractValidator<UpdateVisitorEntryLogCommand>
{
    public UpdateVisitorEntryLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteVisitorEntryLogCommandValidator : AbstractValidator<DeleteVisitorEntryLogCommand>
{
    public DeleteVisitorEntryLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}