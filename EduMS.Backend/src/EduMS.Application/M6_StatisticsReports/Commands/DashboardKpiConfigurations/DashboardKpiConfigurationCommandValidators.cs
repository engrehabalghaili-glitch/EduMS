using FluentValidation;

namespace EduMS.Application.M6_StatisticsReports.Commands.DashboardKpiConfigurations;

public class CreateDashboardKpiConfigurationCommandValidator : AbstractValidator<CreateDashboardKpiConfigurationCommand>
{
    public CreateDashboardKpiConfigurationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateDashboardKpiConfigurationCommandValidator : AbstractValidator<UpdateDashboardKpiConfigurationCommand>
{
    public UpdateDashboardKpiConfigurationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteDashboardKpiConfigurationCommandValidator : AbstractValidator<DeleteDashboardKpiConfigurationCommand>
{
    public DeleteDashboardKpiConfigurationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}