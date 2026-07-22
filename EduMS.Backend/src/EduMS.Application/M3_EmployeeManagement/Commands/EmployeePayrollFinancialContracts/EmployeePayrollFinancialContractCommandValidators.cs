using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeePayrollFinancialContracts;

public class CreateEmployeePayrollFinancialContractCommandValidator : AbstractValidator<CreateEmployeePayrollFinancialContractCommand>
{
    public CreateEmployeePayrollFinancialContractCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeePayrollFinancialContractCommandValidator : AbstractValidator<UpdateEmployeePayrollFinancialContractCommand>
{
    public UpdateEmployeePayrollFinancialContractCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeePayrollFinancialContractCommandValidator : AbstractValidator<DeleteEmployeePayrollFinancialContractCommand>
{
    public DeleteEmployeePayrollFinancialContractCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}