using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.ExceptionalStatisticsReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.ExceptionalStatisticsReports;

public class ExceptionalStatisticsReportQueryHandlers : 
    IRequestHandler<CalculateLiveExceptionalStatisticsReportQuery, string>,
    IRequestHandler<GetExceptionalStatisticsReportSnapshotQuery, ExceptionalStatisticsReportDto>
{
    private readonly IGenericRepository<ExceptionalStatisticsReport> _repository;
    private readonly IMapper _mapper;

    public ExceptionalStatisticsReportQueryHandlers(IGenericRepository<ExceptionalStatisticsReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveExceptionalStatisticsReportQuery request, CancellationToken cancellationToken)
    {
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<ExceptionalStatisticsReportDto> Handle(GetExceptionalStatisticsReportSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ExceptionalStatisticsReport snapshot not found.");
        return _mapper.Map<ExceptionalStatisticsReportDto>(entity);
    }
}