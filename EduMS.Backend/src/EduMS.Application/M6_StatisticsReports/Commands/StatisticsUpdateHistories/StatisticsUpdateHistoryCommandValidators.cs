using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticsUpdateHistories;

public class CreateStatisticsUpdateHistoryCommandValidator : AbstractValidator<CreateStatisticsUpdateHistoryCommand>
{
    public CreateStatisticsUpdateHistoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}