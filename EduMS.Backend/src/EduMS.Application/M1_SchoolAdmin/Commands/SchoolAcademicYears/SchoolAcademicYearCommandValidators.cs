using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAcademicYears;

public class CreateSchoolAcademicYearCommandValidator : AbstractValidator<CreateSchoolAcademicYearCommand>
{
    public CreateSchoolAcademicYearCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolAcademicYearCommandValidator : AbstractValidator<UpdateSchoolAcademicYearCommand>
{
    public UpdateSchoolAcademicYearCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolAcademicYearCommandValidator : AbstractValidator<DeleteSchoolAcademicYearCommand>
{
    public DeleteSchoolAcademicYearCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}