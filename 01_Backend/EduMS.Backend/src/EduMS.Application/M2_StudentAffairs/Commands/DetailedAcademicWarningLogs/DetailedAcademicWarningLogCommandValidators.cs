using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.DetailedAcademicWarningLogs;

public class CreateDetailedAcademicWarningLogCommandValidator : AbstractValidator<CreateDetailedAcademicWarningLogCommand>
{
    public CreateDetailedAcademicWarningLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateDetailedAcademicWarningLogCommandValidator : AbstractValidator<UpdateDetailedAcademicWarningLogCommand>
{
    public UpdateDetailedAcademicWarningLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteDetailedAcademicWarningLogCommandValidator : AbstractValidator<DeleteDetailedAcademicWarningLogCommand>
{
    public DeleteDetailedAcademicWarningLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}