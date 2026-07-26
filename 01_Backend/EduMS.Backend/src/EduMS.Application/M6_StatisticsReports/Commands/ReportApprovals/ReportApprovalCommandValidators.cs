using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.ReportApprovals;

public class DraftReportApprovalCommandValidator : AbstractValidator<DraftReportApprovalCommand>
{
    public DraftReportApprovalCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveReportApprovalCommandValidator : AbstractValidator<ApproveReportApprovalCommand>
{
    public ApproveReportApprovalCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}