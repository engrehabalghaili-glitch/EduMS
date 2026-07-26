using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentTransportPreferences;

public class CreateStudentTransportPreferenceCommandValidator : AbstractValidator<CreateStudentTransportPreferenceCommand>
{
    public CreateStudentTransportPreferenceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentTransportPreferenceCommandValidator : AbstractValidator<UpdateStudentTransportPreferenceCommand>
{
    public UpdateStudentTransportPreferenceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentTransportPreferenceCommandValidator : AbstractValidator<DeleteStudentTransportPreferenceCommand>
{
    public DeleteStudentTransportPreferenceCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}