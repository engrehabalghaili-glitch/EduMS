using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExemplaryRecognitions;

public class CreateStudentExemplaryRecognitionCommandValidator : AbstractValidator<CreateStudentExemplaryRecognitionCommand>
{
    public CreateStudentExemplaryRecognitionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentExemplaryRecognitionCommandValidator : AbstractValidator<UpdateStudentExemplaryRecognitionCommand>
{
    public UpdateStudentExemplaryRecognitionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentExemplaryRecognitionCommandValidator : AbstractValidator<DeleteStudentExemplaryRecognitionCommand>
{
    public DeleteStudentExemplaryRecognitionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}