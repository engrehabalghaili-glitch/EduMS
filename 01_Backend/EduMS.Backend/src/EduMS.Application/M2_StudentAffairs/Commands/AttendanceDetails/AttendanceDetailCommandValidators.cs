using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.AttendanceDetails;

public class CreateAttendanceDetailCommandValidator : AbstractValidator<CreateAttendanceDetailCommand>
{
    public CreateAttendanceDetailCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAttendanceDetailCommandValidator : AbstractValidator<UpdateAttendanceDetailCommand>
{
    public UpdateAttendanceDetailCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAttendanceDetailCommandValidator : AbstractValidator<DeleteAttendanceDetailCommand>
{
    public DeleteAttendanceDetailCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}