using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialSummaryReports;

public class CreateAssetFinancialSummaryReportCommandValidator : AbstractValidator<CreateAssetFinancialSummaryReportCommand>
{
    public CreateAssetFinancialSummaryReportCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetFinancialSummaryReportCommandValidator : AbstractValidator<UpdateAssetFinancialSummaryReportCommand>
{
    public UpdateAssetFinancialSummaryReportCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetFinancialSummaryReportCommandValidator : AbstractValidator<DeleteAssetFinancialSummaryReportCommand>
{
    public DeleteAssetFinancialSummaryReportCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}