using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeFinancialTransactions;

public class CreateEmployeeFinancialTransactionCommandValidator : AbstractValidator<CreateEmployeeFinancialTransactionCommand>
{
    public CreateEmployeeFinancialTransactionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeFinancialTransactionCommandValidator : AbstractValidator<UpdateEmployeeFinancialTransactionCommand>
{
    public UpdateEmployeeFinancialTransactionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeFinancialTransactionCommandValidator : AbstractValidator<DeleteEmployeeFinancialTransactionCommand>
{
    public DeleteEmployeeFinancialTransactionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}