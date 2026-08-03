using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicLockPeriods;

public class CreateAcademicLockPeriodCommandValidator : AbstractValidator<CreateAcademicLockPeriodCommand>
{
    public CreateAcademicLockPeriodCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAcademicLockPeriodCommandValidator : AbstractValidator<UpdateAcademicLockPeriodCommand>
{
    public UpdateAcademicLockPeriodCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAcademicLockPeriodCommandValidator : AbstractValidator<DeleteAcademicLockPeriodCommand>
{
    public DeleteAcademicLockPeriodCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}