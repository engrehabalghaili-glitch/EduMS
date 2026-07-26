using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.ReportApprovals;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.ReportApprovals;

public class ReportApprovalQueryHandlers : 
    IRequestHandler<CalculateLiveReportApprovalQuery, string>,
    IRequestHandler<GetReportApprovalSnapshotQuery, ReportApprovalDto>
{
    private readonly IGenericRepository<ReportApproval> _repository;
    private readonly IMapper _mapper;

    public ReportApprovalQueryHandlers(IGenericRepository<ReportApproval> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<string> Handle(CalculateLiveReportApprovalQuery request, CancellationToken cancellationToken)
    {
        var dynamicResultJson = "{ \"result\": \"dynamic calculation\" }";
        return Task.FromResult(dynamicResultJson);
    }

    public async Task<ReportApprovalDto> Handle(GetReportApprovalSnapshotQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"ReportApproval snapshot not found.");
        return _mapper.Map<ReportApprovalDto>(entity);
    }
}