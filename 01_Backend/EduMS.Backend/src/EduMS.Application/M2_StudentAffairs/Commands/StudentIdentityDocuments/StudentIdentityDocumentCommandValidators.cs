using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentIdentityDocuments;

public class CreateStudentIdentityDocumentCommandValidator : AbstractValidator<CreateStudentIdentityDocumentCommand>
{
    public CreateStudentIdentityDocumentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentIdentityDocumentCommandValidator : AbstractValidator<UpdateStudentIdentityDocumentCommand>
{
    public UpdateStudentIdentityDocumentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentIdentityDocumentCommandValidator : AbstractValidator<DeleteStudentIdentityDocumentCommand>
{
    public DeleteStudentIdentityDocumentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}