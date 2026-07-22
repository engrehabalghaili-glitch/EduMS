using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeDocuments;

public class CreateEmployeeDocumentCommandValidator : AbstractValidator<CreateEmployeeDocumentCommand>
{
    public CreateEmployeeDocumentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeDocumentCommandValidator : AbstractValidator<UpdateEmployeeDocumentCommand>
{
    public UpdateEmployeeDocumentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeDocumentCommandValidator : AbstractValidator<DeleteEmployeeDocumentCommand>
{
    public DeleteEmployeeDocumentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}