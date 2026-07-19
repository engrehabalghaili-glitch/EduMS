using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.SubmittedStatisticses;

public class CreateSubmittedStatisticsCommandValidator : AbstractValidator<CreateSubmittedStatisticsCommand>
{
    public CreateSubmittedStatisticsCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}