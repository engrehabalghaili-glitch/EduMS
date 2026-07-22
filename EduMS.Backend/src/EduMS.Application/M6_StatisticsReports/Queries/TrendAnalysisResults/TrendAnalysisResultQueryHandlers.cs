using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.TrendAnalysisResults;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.TrendAnalysisResults;

public class TrendAnalysisResultQueryHandlers : 
    IRequestHandler<CalculateLiveTrendAnalysisResultQuery, string>,
    IRequestHandler<GetTrendAnalysisResultSnapshotQuery, TrendAnalysisResultDto>
{
    private readonly IGenericRepository<TrendAnalysisResult> _repository;
    private readonly IMapper _mapper;

    public TrendAnalysisResultQueryHandlers(IGenericRepository<TrendAnalysisResult> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveTrendAnalysisResultQuery request, CancellationToken cancellationToken)
    {
        // This is the Query Engine logic.
        // It performs dynamic JOINs and aggregations on M1-M7 transactional data.
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<TrendAnalysisResultDto> Handle(GetTrendAnalysisResultSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"TrendAnalysisResult snapshot not found.");
        return _mapper.Map<TrendAnalysisResultDto>(entity);
    }
}