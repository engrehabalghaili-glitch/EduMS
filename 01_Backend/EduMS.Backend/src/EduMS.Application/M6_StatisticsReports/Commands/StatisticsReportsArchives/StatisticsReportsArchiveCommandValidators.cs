using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticsReportsArchives;

public class CreateStatisticsReportsArchiveCommandValidator : AbstractValidator<CreateStatisticsReportsArchiveCommand>
{
    public CreateStatisticsReportsArchiveCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}