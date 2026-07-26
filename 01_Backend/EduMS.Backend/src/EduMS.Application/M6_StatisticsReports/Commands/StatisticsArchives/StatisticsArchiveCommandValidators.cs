using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticsArchives;

public class CreateStatisticsArchiveCommandValidator : AbstractValidator<CreateStatisticsArchiveCommand>
{
    public CreateStatisticsArchiveCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}