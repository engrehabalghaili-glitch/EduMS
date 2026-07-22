using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassSchedules;

public class CreateClassScheduleCommandValidator : AbstractValidator<CreateClassScheduleCommand>
{
    public CreateClassScheduleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateClassScheduleCommandValidator : AbstractValidator<UpdateClassScheduleCommand>
{
    public UpdateClassScheduleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteClassScheduleCommandValidator : AbstractValidator<DeleteClassScheduleCommand>
{
    public DeleteClassScheduleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}