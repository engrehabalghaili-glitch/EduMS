using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.TrendAnalysisResults;

public class DraftTrendAnalysisResultCommandValidator : AbstractValidator<DraftTrendAnalysisResultCommand>
{
    public DraftTrendAnalysisResultCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveTrendAnalysisResultCommandValidator : AbstractValidator<ApproveTrendAnalysisResultCommand>
{
    public ApproveTrendAnalysisResultCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}