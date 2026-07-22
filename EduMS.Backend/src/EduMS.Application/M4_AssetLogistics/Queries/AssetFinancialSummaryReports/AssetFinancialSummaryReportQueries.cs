using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialSummaryReports;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialSummaryReports;

public class GetAssetFinancialSummaryReportByIdQuery : IRequest<AssetFinancialSummaryReportDto>
{
    public long Id { get; set; }
}

public class GetAllAssetFinancialSummaryReportsQuery : IRequest<IEnumerable<AssetFinancialSummaryReportDto>>
{
}