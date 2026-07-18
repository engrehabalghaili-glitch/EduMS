using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M3_EmployeeManagement.DTOs.AppointmentDecisions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M3_EmployeeManagement.Queries.AppointmentDecisions;

public class AppointmentDecisionQueryHandlers : 
    IRequestHandler<GetAppointmentDecisionByIdQuery, AppointmentDecisionDto>,
    IRequestHandler<GetAllAppointmentDecisionsQuery, IEnumerable<AppointmentDecisionDto>>
{
    private readonly IGenericRepository<AppointmentDecision> _repository;
    private readonly IMapper _mapper;

    public AppointmentDecisionQueryHandlers(IGenericRepository<AppointmentDecision> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AppointmentDecisionDto> Handle(GetAppointmentDecisionByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"AppointmentDecision not found.");
        return _mapper.Map<AppointmentDecisionDto>(entity);
    }

    public async Task<IEnumerable<AppointmentDecisionDto>> Handle(GetAllAppointmentDecisionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<AppointmentDecisionDto>>(entities);
    }
}