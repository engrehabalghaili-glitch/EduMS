using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.PayrollRuns;

public class CreatePayrollRunCommandValidator : AbstractValidator<CreatePayrollRunCommand>
{
    public CreatePayrollRunCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdatePayrollRunCommandValidator : AbstractValidator<UpdatePayrollRunCommand>
{
    public UpdatePayrollRunCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeletePayrollRunCommandValidator : AbstractValidator<DeletePayrollRunCommand>
{
    public DeletePayrollRunCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}