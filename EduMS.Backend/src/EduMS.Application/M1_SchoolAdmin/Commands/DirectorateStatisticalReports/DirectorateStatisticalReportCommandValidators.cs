using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateStatisticalReports;

public class CreateDirectorateStatisticalReportCommandValidator : AbstractValidator<CreateDirectorateStatisticalReportCommand>
{
    public CreateDirectorateStatisticalReportCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateDirectorateStatisticalReportCommandValidator : AbstractValidator<UpdateDirectorateStatisticalReportCommand>
{
    public UpdateDirectorateStatisticalReportCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteDirectorateStatisticalReportCommandValidator : AbstractValidator<DeleteDirectorateStatisticalReportCommand>
{
    public DeleteDirectorateStatisticalReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}