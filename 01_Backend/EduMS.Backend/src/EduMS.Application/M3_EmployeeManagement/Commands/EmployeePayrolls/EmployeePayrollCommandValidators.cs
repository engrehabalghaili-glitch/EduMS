using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeePayrolls;

public class CreateEmployeePayrollCommandValidator : AbstractValidator<CreateEmployeePayrollCommand>
{
    public CreateEmployeePayrollCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeePayrollCommandValidator : AbstractValidator<UpdateEmployeePayrollCommand>
{
    public UpdateEmployeePayrollCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeePayrollCommandValidator : AbstractValidator<DeleteEmployeePayrollCommand>
{
    public DeleteEmployeePayrollCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}