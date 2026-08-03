using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.ComparativeReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.ComparativeReports;

public class ComparativeReportQueryHandlers : 
    IRequestHandler<CalculateLiveComparativeReportQuery, string>,
    IRequestHandler<GetComparativeReportSnapshotQuery, ComparativeReportDto>
{
    private readonly IGenericRepository<ComparativeReport> _repository;
    private readonly IMapper _mapper;

    public ComparativeReportQueryHandlers(IGenericRepository<ComparativeReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveComparativeReportQuery request, CancellationToken cancellationToken)
    {
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<ComparativeReportDto> Handle(GetComparativeReportSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ComparativeReport snapshot not found.");
        return _mapper.Map<ComparativeReportDto>(entity);
    }
}