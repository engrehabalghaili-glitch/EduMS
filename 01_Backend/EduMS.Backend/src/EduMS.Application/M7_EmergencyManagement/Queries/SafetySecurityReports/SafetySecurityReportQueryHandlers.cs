using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.SafetySecurityReports;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SafetySecurityReports;

public class SafetySecurityReportQueryHandlers : 
    IRequestHandler<GetSafetySecurityReportByIdQuery, SafetySecurityReportDto>,
    IRequestHandler<GetAllSafetySecurityReportsQuery, IEnumerable<SafetySecurityReportDto>>
{
    private readonly IGenericRepository<SafetySecurityReport> _repository;
    private readonly IMapper _mapper;

    public SafetySecurityReportQueryHandlers(IGenericRepository<SafetySecurityReport> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SafetySecurityReportDto> Handle(GetSafetySecurityReportByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"SafetySecurityReport not found.");
        return _mapper.Map<SafetySecurityReportDto>(entity);
    }

    public async Task<IEnumerable<SafetySecurityReportDto>> Handle(GetAllSafetySecurityReportsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<SafetySecurityReportDto>>(entities);
    }
}