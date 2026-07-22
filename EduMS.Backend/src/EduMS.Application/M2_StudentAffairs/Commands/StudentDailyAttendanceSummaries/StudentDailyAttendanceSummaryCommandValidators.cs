using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentDailyAttendanceSummaries;

public class CreateStudentDailyAttendanceSummaryCommandValidator : AbstractValidator<CreateStudentDailyAttendanceSummaryCommand>
{
    public CreateStudentDailyAttendanceSummaryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentDailyAttendanceSummaryCommandValidator : AbstractValidator<UpdateStudentDailyAttendanceSummaryCommand>
{
    public UpdateStudentDailyAttendanceSummaryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentDailyAttendanceSummaryCommandValidator : AbstractValidator<DeleteStudentDailyAttendanceSummaryCommand>
{
    public DeleteStudentDailyAttendanceSummaryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}