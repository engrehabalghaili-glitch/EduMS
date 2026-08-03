using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.ComparativeReports;

public class DraftComparativeReportCommandValidator : AbstractValidator<DraftComparativeReportCommand>
{
    public DraftComparativeReportCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveComparativeReportCommandValidator : AbstractValidator<ApproveComparativeReportCommand>
{
    public ApproveComparativeReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}