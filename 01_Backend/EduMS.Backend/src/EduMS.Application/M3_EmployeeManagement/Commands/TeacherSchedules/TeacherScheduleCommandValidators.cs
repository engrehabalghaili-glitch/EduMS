using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.TeacherSchedules;

public class CreateTeacherScheduleCommandValidator : AbstractValidator<CreateTeacherScheduleCommand>
{
    public CreateTeacherScheduleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateTeacherScheduleCommandValidator : AbstractValidator<UpdateTeacherScheduleCommand>
{
    public UpdateTeacherScheduleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteTeacherScheduleCommandValidator : AbstractValidator<DeleteTeacherScheduleCommand>
{
    public DeleteTeacherScheduleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}