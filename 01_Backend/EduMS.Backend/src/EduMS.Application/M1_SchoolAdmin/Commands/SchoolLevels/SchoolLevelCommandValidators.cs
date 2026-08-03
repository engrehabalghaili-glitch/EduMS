using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolLevels;

public class CreateSchoolLevelCommandValidator : AbstractValidator<CreateSchoolLevelCommand>
{
    public CreateSchoolLevelCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolLevelCommandValidator : AbstractValidator<UpdateSchoolLevelCommand>
{
    public UpdateSchoolLevelCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolLevelCommandValidator : AbstractValidator<DeleteSchoolLevelCommand>
{
    public DeleteSchoolLevelCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}