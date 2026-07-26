using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.InvoiceItems;

public class CreateInvoiceItemCommandValidator : AbstractValidator<CreateInvoiceItemCommand>
{
    public CreateInvoiceItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateInvoiceItemCommandValidator : AbstractValidator<UpdateInvoiceItemCommand>
{
    public UpdateInvoiceItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteInvoiceItemCommandValidator : AbstractValidator<DeleteInvoiceItemCommand>
{
    public DeleteInvoiceItemCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}