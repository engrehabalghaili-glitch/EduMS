using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateLegalCaseLogs;

public class CreateDirectorateLegalCaseLogCommandValidator : AbstractValidator<CreateDirectorateLegalCaseLogCommand>
{
    public CreateDirectorateLegalCaseLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateDirectorateLegalCaseLogCommandValidator : AbstractValidator<UpdateDirectorateLegalCaseLogCommand>
{
    public UpdateDirectorateLegalCaseLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteDirectorateLegalCaseLogCommandValidator : AbstractValidator<DeleteDirectorateLegalCaseLogCommand>
{
    public DeleteDirectorateLegalCaseLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}