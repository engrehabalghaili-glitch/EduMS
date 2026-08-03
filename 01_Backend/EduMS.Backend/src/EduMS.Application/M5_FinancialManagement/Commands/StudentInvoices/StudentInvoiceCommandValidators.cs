using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.StudentInvoices;

public class CreateStudentInvoiceCommandValidator : AbstractValidator<CreateStudentInvoiceCommand>
{
    public CreateStudentInvoiceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentInvoiceCommandValidator : AbstractValidator<UpdateStudentInvoiceCommand>
{
    public UpdateStudentInvoiceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentInvoiceCommandValidator : AbstractValidator<DeleteStudentInvoiceCommand>
{
    public DeleteStudentInvoiceCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}