using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeTrainings;

public class CreateEmployeeTrainingCommandValidator : AbstractValidator<CreateEmployeeTrainingCommand>
{
    public CreateEmployeeTrainingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeTrainingCommandValidator : AbstractValidator<UpdateEmployeeTrainingCommand>
{
    public UpdateEmployeeTrainingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeTrainingCommandValidator : AbstractValidator<DeleteEmployeeTrainingCommand>
{
    public DeleteEmployeeTrainingCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}