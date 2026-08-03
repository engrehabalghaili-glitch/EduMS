using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeLeaves;

public class CreateEmployeeLeaveCommandValidator : AbstractValidator<CreateEmployeeLeaveCommand>
{
    public CreateEmployeeLeaveCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeLeaveCommandValidator : AbstractValidator<UpdateEmployeeLeaveCommand>
{
    public UpdateEmployeeLeaveCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeLeaveCommandValidator : AbstractValidator<DeleteEmployeeLeaveCommand>
{
    public DeleteEmployeeLeaveCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}