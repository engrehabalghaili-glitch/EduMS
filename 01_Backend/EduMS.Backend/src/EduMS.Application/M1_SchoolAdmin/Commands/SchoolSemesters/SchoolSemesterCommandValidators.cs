using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolSemesters;

public class CreateSchoolSemesterCommandValidator : AbstractValidator<CreateSchoolSemesterCommand>
{
    public CreateSchoolSemesterCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolSemesterCommandValidator : AbstractValidator<UpdateSchoolSemesterCommand>
{
    public UpdateSchoolSemesterCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolSemesterCommandValidator : AbstractValidator<DeleteSchoolSemesterCommand>
{
    public DeleteSchoolSemesterCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}