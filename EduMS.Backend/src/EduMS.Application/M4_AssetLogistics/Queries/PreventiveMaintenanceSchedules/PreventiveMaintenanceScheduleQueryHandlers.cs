using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.PreventiveMaintenanceSchedules;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.PreventiveMaintenanceSchedules;

public class PreventiveMaintenanceScheduleQueryHandlers : 
    IRequestHandler<GetPreventiveMaintenanceScheduleByIdQuery, PreventiveMaintenanceScheduleDto>,
    IRequestHandler<GetAllPreventiveMaintenanceSchedulesQuery, IEnumerable<PreventiveMaintenanceScheduleDto>>
{
    private readonly IGenericRepository<PreventiveMaintenanceSchedule> _repository;
    private readonly IMapper _mapper;

    public PreventiveMaintenanceScheduleQueryHandlers(IGenericRepository<PreventiveMaintenanceSchedule> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PreventiveMaintenanceScheduleDto> Handle(GetPreventiveMaintenanceScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PreventiveMaintenanceSchedule not found.");
        return _mapper.Map<PreventiveMaintenanceScheduleDto>(entity);
    }

    public async Task<IEnumerable<PreventiveMaintenanceScheduleDto>> Handle(GetAllPreventiveMaintenanceSchedulesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PreventiveMaintenanceScheduleDto>>(entities);
    }
}