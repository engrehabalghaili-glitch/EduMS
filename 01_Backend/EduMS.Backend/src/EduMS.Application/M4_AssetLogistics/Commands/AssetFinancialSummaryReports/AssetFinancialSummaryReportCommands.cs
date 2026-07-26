using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialSummaryReports;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialSummaryReports;

public class CreateAssetFinancialSummaryReportCommand : IRequest<long>
{
    public CreateAssetFinancialSummaryReportDto Dto { get; set; } = new();
}

public class UpdateAssetFinancialSummaryReportCommand : IRequest<bool>
{
    public UpdateAssetFinancialSummaryReportDto Dto { get; set; } = new();
}

public class DeleteAssetFinancialSummaryReportCommand : IRequest<bool>
{
    public long Id { get; set; }
}