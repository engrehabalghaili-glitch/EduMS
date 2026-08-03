using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.SystemReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.SystemReports;

public class SystemReportQueryHandlers : 
    IRequestHandler<CalculateLiveSystemReportQuery, string>,
    IRequestHandler<GetSystemReportSnapshotQuery, SystemReportDto>
{
    private readonly IGenericRepository<SystemReport> _repository;
    private readonly IMapper _mapper;

    public SystemReportQueryHandlers(IGenericRepository<SystemReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveSystemReportQuery request, CancellationToken cancellationToken)
    {
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<SystemReportDto> Handle(GetSystemReportSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SystemReport snapshot not found.");
        return _mapper.Map<SystemReportDto>(entity);
    }
}