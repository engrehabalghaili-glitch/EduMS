using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.ExceptionalStatisticsReports;

public class DraftExceptionalStatisticsReportCommandValidator : AbstractValidator<DraftExceptionalStatisticsReportCommand>
{
    public DraftExceptionalStatisticsReportCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveExceptionalStatisticsReportCommandValidator : AbstractValidator<ApproveExceptionalStatisticsReportCommand>
{
    public ApproveExceptionalStatisticsReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}