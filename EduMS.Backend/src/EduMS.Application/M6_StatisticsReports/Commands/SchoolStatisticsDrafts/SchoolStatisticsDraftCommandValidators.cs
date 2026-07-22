using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.SchoolStatisticsDrafts;

public class DraftSchoolStatisticsDraftCommandValidator : AbstractValidator<DraftSchoolStatisticsDraftCommand>
{
    public DraftSchoolStatisticsDraftCommandValidator()
    {
        RuleFor(x => x.SchoolId).GreaterThan(0);
    }
}

public class ApproveSchoolStatisticsDraftCommandValidator : AbstractValidator<ApproveSchoolStatisticsDraftCommand>
{
    public ApproveSchoolStatisticsDraftCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.ApprovedByUserId).GreaterThan(0);
    }
}