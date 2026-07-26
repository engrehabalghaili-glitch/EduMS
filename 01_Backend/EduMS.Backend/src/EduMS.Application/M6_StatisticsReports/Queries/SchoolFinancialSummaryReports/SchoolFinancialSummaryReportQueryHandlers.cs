using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.SchoolFinancialSummaryReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.SchoolFinancialSummaryReports;

public class SchoolFinancialSummaryReportQueryHandlers : 
    IRequestHandler<CalculateLiveSchoolFinancialSummaryReportQuery, string>,
    IRequestHandler<GetSchoolFinancialSummaryReportSnapshotQuery, SchoolFinancialSummaryReportDto>
{
    private readonly IGenericRepository<SchoolFinancialSummaryReport> _repository;
    private readonly IMapper _mapper;

    public SchoolFinancialSummaryReportQueryHandlers(IGenericRepository<SchoolFinancialSummaryReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveSchoolFinancialSummaryReportQuery request, CancellationToken cancellationToken)
    {
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<SchoolFinancialSummaryReportDto> Handle(GetSchoolFinancialSummaryReportSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SchoolFinancialSummaryReport snapshot not found.");
        return _mapper.Map<SchoolFinancialSummaryReportDto>(entity);
    }
}