using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticalReportSnapshots;

public class CreateStatisticalReportSnapshotCommandValidator : AbstractValidator<CreateStatisticalReportSnapshotCommand>
{
    public CreateStatisticalReportSnapshotCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}