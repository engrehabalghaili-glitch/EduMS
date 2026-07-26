using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.ExternalComplianceReports;

public class DraftExternalComplianceReportCommandValidator : AbstractValidator<DraftExternalComplianceReportCommand>
{
    public DraftExternalComplianceReportCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveExternalComplianceReportCommandValidator : AbstractValidator<ApproveExternalComplianceReportCommand>
{
    public ApproveExternalComplianceReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}