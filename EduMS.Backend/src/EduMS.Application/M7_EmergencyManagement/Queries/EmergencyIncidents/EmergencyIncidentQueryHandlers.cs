using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyIncidents;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyIncidents;

public class EmergencyIncidentQueryHandlers : 
    IRequestHandler<GetEmergencyIncidentByIdQuery, EmergencyIncidentDto>,
    IRequestHandler<GetAllEmergencyIncidentsQuery, IEnumerable<EmergencyIncidentDto>>
{
    private readonly IGenericRepository<EmergencyIncident> _repository;
    private readonly IMapper _mapper;

    public EmergencyIncidentQueryHandlers(IGenericRepository<EmergencyIncident> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmergencyIncidentDto> Handle(GetEmergencyIncidentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmergencyIncident not found.");
        return _mapper.Map<EmergencyIncidentDto>(entity);
    }

    public async Task<IEnumerable<EmergencyIncidentDto>> Handle(GetAllEmergencyIncidentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmergencyIncidentDto>>(entities);
    }
}