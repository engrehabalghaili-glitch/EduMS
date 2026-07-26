using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.SchoolFinancialSummaryReports;

public class DraftSchoolFinancialSummaryReportCommandValidator : AbstractValidator<DraftSchoolFinancialSummaryReportCommand>
{
    public DraftSchoolFinancialSummaryReportCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveSchoolFinancialSummaryReportCommandValidator : AbstractValidator<ApproveSchoolFinancialSummaryReportCommand>
{
    public ApproveSchoolFinancialSummaryReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}