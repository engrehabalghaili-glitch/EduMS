using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentParentConferenceReservations;

public class CreateStudentParentConferenceReservationCommandValidator : AbstractValidator<CreateStudentParentConferenceReservationCommand>
{
    public CreateStudentParentConferenceReservationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentParentConferenceReservationCommandValidator : AbstractValidator<UpdateStudentParentConferenceReservationCommand>
{
    public UpdateStudentParentConferenceReservationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentParentConferenceReservationCommandValidator : AbstractValidator<DeleteStudentParentConferenceReservationCommand>
{
    public DeleteStudentParentConferenceReservationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}