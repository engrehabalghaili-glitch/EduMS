using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.KpiMetricRecords;

public class DraftKpiMetricRecordCommandValidator : AbstractValidator<DraftKpiMetricRecordCommand>
{
    public DraftKpiMetricRecordCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveKpiMetricRecordCommandValidator : AbstractValidator<ApproveKpiMetricRecordCommand>
{
    public ApproveKpiMetricRecordCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}