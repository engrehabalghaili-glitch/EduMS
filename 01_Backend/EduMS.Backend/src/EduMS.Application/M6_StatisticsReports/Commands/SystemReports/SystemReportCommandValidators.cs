using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.SystemReports;

public class DraftSystemReportCommandValidator : AbstractValidator<DraftSystemReportCommand>
{
    public DraftSystemReportCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveSystemReportCommandValidator : AbstractValidator<ApproveSystemReportCommand>
{
    public ApproveSystemReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}