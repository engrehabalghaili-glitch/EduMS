using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.PayrollDetails;

public class CreatePayrollDetailCommandValidator : AbstractValidator<CreatePayrollDetailCommand>
{
    public CreatePayrollDetailCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdatePayrollDetailCommandValidator : AbstractValidator<UpdatePayrollDetailCommand>
{
    public UpdatePayrollDetailCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeletePayrollDetailCommandValidator : AbstractValidator<DeletePayrollDetailCommand>
{
    public DeletePayrollDetailCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}