using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAttachments;

public class CreateStudentAttachmentCommandValidator : AbstractValidator<CreateStudentAttachmentCommand>
{
    public CreateStudentAttachmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentAttachmentCommandValidator : AbstractValidator<UpdateStudentAttachmentCommand>
{
    public UpdateStudentAttachmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentAttachmentCommandValidator : AbstractValidator<DeleteStudentAttachmentCommand>
{
    public DeleteStudentAttachmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}