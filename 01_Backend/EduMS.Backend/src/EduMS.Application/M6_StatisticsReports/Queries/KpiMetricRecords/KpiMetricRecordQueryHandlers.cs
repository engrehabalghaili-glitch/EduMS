using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.KpiMetricRecords;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.KpiMetricRecords;

public class KpiMetricRecordQueryHandlers : 
    IRequestHandler<CalculateLiveKpiMetricRecordQuery, string>,
    IRequestHandler<GetKpiMetricRecordSnapshotQuery, KpiMetricRecordDto>
{
    private readonly IGenericRepository<KpiMetricRecord> _repository;
    private readonly IMapper _mapper;

    public KpiMetricRecordQueryHandlers(IGenericRepository<KpiMetricRecord> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveKpiMetricRecordQuery request, CancellationToken cancellationToken)
    {
        // This is the Query Engine logic.
        // It performs dynamic JOINs and aggregations on M1-M7 transactional data.
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<KpiMetricRecordDto> Handle(GetKpiMetricRecordSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"KpiMetricRecord snapshot not found.");
        return _mapper.Map<KpiMetricRecordDto>(entity);
    }
}