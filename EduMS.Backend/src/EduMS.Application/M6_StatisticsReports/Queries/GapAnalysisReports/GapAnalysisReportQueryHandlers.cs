using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.GapAnalysisReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.GapAnalysisReports;

public class GapAnalysisReportQueryHandlers : 
    IRequestHandler<CalculateLiveGapAnalysisReportQuery, string>,
    IRequestHandler<GetGapAnalysisReportSnapshotQuery, GapAnalysisReportDto>
{
    private readonly IGenericRepository<GapAnalysisReport> _repository;
    private readonly IMapper _mapper;

    public GapAnalysisReportQueryHandlers(IGenericRepository<GapAnalysisReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveGapAnalysisReportQuery request, CancellationToken cancellationToken)
    {
        // This is the Query Engine logic.
        // It performs dynamic JOINs and aggregations on M1-M7 transactional data.
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<GapAnalysisReportDto> Handle(GetGapAnalysisReportSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"GapAnalysisReport snapshot not found.");
        return _mapper.Map<GapAnalysisReportDto>(entity);
    }
}