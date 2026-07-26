using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeTerminations;

public class CreateEmployeeTerminationCommandValidator : AbstractValidator<CreateEmployeeTerminationCommand>
{
    public CreateEmployeeTerminationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeTerminationCommandValidator : AbstractValidator<UpdateEmployeeTerminationCommand>
{
    public UpdateEmployeeTerminationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeTerminationCommandValidator : AbstractValidator<DeleteEmployeeTerminationCommand>
{
    public DeleteEmployeeTerminationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}