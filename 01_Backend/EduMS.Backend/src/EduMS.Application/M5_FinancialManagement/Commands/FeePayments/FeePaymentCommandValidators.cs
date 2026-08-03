using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeePayments;

public class CreateFeePaymentCommandValidator : AbstractValidator<CreateFeePaymentCommand>
{
    public CreateFeePaymentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateFeePaymentCommandValidator : AbstractValidator<UpdateFeePaymentCommand>
{
    public UpdateFeePaymentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteFeePaymentCommandValidator : AbstractValidator<DeleteFeePaymentCommand>
{
    public DeleteFeePaymentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}