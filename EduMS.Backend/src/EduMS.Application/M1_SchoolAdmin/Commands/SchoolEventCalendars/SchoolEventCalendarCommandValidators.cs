using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolEventCalendars;

public class CreateSchoolEventCalendarCommandValidator : AbstractValidator<CreateSchoolEventCalendarCommand>
{
    public CreateSchoolEventCalendarCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolEventCalendarCommandValidator : AbstractValidator<UpdateSchoolEventCalendarCommand>
{
    public UpdateSchoolEventCalendarCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolEventCalendarCommandValidator : AbstractValidator<DeleteSchoolEventCalendarCommand>
{
    public DeleteSchoolEventCalendarCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}