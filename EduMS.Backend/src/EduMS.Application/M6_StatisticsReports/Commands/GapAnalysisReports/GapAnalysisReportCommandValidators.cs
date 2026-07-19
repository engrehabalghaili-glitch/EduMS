using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.GapAnalysisReports;

public class DraftGapAnalysisReportCommandValidator : AbstractValidator<DraftGapAnalysisReportCommand>
{
    public DraftGapAnalysisReportCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveGapAnalysisReportCommandValidator : AbstractValidator<ApproveGapAnalysisReportCommand>
{
    public ApproveGapAnalysisReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}