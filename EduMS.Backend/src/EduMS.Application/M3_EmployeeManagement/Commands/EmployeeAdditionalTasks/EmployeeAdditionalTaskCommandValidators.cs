using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeAdditionalTasks;

public class CreateEmployeeAdditionalTaskCommandValidator : AbstractValidator<CreateEmployeeAdditionalTaskCommand>
{
    public CreateEmployeeAdditionalTaskCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeAdditionalTaskCommandValidator : AbstractValidator<UpdateEmployeeAdditionalTaskCommand>
{
    public UpdateEmployeeAdditionalTaskCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeAdditionalTaskCommandValidator : AbstractValidator<DeleteEmployeeAdditionalTaskCommand>
{
    public DeleteEmployeeAdditionalTaskCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}