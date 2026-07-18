using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeViolations;

public class CreateEmployeeViolationCommandValidator : AbstractValidator<CreateEmployeeViolationCommand>
{
    public CreateEmployeeViolationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeViolationCommandValidator : AbstractValidator<UpdateEmployeeViolationCommand>
{
    public UpdateEmployeeViolationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeViolationCommandValidator : AbstractValidator<DeleteEmployeeViolationCommand>
{
    public DeleteEmployeeViolationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}