using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentActivityParticipations;

public class CreateStudentActivityParticipationCommandValidator : AbstractValidator<CreateStudentActivityParticipationCommand>
{
    public CreateStudentActivityParticipationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentActivityParticipationCommandValidator : AbstractValidator<UpdateStudentActivityParticipationCommand>
{
    public UpdateStudentActivityParticipationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentActivityParticipationCommandValidator : AbstractValidator<DeleteStudentActivityParticipationCommand>
{
    public DeleteStudentActivityParticipationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}