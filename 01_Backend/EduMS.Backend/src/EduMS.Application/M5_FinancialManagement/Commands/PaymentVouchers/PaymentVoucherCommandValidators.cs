using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.PaymentVouchers;

public class CreatePaymentVoucherCommandValidator : AbstractValidator<CreatePaymentVoucherCommand>
{
    public CreatePaymentVoucherCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdatePaymentVoucherCommandValidator : AbstractValidator<UpdatePaymentVoucherCommand>
{
    public UpdatePaymentVoucherCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeletePaymentVoucherCommandValidator : AbstractValidator<DeletePaymentVoucherCommand>
{
    public DeletePaymentVoucherCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}