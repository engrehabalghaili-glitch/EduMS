using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolShifts;

public class CreateSchoolShiftCommandValidator : AbstractValidator<CreateSchoolShiftCommand>
{
    public CreateSchoolShiftCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolShiftCommandValidator : AbstractValidator<UpdateSchoolShiftCommand>
{
    public UpdateSchoolShiftCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolShiftCommandValidator : AbstractValidator<DeleteSchoolShiftCommand>
{
    public DeleteSchoolShiftCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}