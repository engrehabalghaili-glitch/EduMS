using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M6_StatisticsReports.DTOs.DashboardKpiConfigurations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M6_StatisticsReports.Queries.DashboardKpiConfigurations;

public class DashboardKpiConfigurationQueryHandlers : 
    IRequestHandler<GetDashboardKpiConfigurationByIdQuery, DashboardKpiConfigurationDto>,
    IRequestHandler<GetAllDashboardKpiConfigurationsQuery, IEnumerable<DashboardKpiConfigurationDto>>
{
    private readonly IGenericRepository<DashboardKpiConfiguration> _repository;
    private readonly IMapper _mapper;

    public DashboardKpiConfigurationQueryHandlers(IGenericRepository<DashboardKpiConfiguration> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DashboardKpiConfigurationDto> Handle(GetDashboardKpiConfigurationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"DashboardKpiConfiguration not found.");
        return _mapper.Map<DashboardKpiConfigurationDto>(entity);
    }

    public async Task<IEnumerable<DashboardKpiConfigurationDto>> Handle(GetAllDashboardKpiConfigurationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DashboardKpiConfigurationDto>>(entities);
    }
}