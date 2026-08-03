using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.ExternalComplianceReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.ExternalComplianceReports;

public class ExternalComplianceReportQueryHandlers : 
    IRequestHandler<CalculateLiveExternalComplianceReportQuery, string>,
    IRequestHandler<GetExternalComplianceReportSnapshotQuery, ExternalComplianceReportDto>
{
    private readonly IGenericRepository<ExternalComplianceReport> _repository;
    private readonly IMapper _mapper;

    public ExternalComplianceReportQueryHandlers(IGenericRepository<ExternalComplianceReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveExternalComplianceReportQuery request, CancellationToken cancellationToken)
    {
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<ExternalComplianceReportDto> Handle(GetExternalComplianceReportSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ExternalComplianceReport snapshot not found.");
        return _mapper.Map<ExternalComplianceReportDto>(entity);
    }
}