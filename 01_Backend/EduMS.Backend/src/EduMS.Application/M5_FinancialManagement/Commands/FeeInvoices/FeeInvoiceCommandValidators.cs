using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeInvoices;

public class CreateFeeInvoiceCommandValidator : AbstractValidator<CreateFeeInvoiceCommand>
{
    public CreateFeeInvoiceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateFeeInvoiceCommandValidator : AbstractValidator<UpdateFeeInvoiceCommand>
{
    public UpdateFeeInvoiceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteFeeInvoiceCommandValidator : AbstractValidator<DeleteFeeInvoiceCommand>
{
    public DeleteFeeInvoiceCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}