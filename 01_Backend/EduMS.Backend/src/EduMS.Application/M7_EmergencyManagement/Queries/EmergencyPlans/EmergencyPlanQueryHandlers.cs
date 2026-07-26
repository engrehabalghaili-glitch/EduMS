using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyPlans;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyPlans;

public class EmergencyPlanQueryHandlers : 
    IRequestHandler<GetEmergencyPlanByIdQuery, EmergencyPlanDto>,
    IRequestHandler<GetAllEmergencyPlansQuery, IEnumerable<EmergencyPlanDto>>
{
    private readonly IGenericRepository<EmergencyPlan> _repository;
    private readonly IMapper _mapper;

    public EmergencyPlanQueryHandlers(IGenericRepository<EmergencyPlan> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EmergencyPlanDto> Handle(GetEmergencyPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"EmergencyPlan not found.");
        return _mapper.Map<EmergencyPlanDto>(entity);
    }

    public async Task<IEnumerable<EmergencyPlanDto>> Handle(GetAllEmergencyPlansQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<EmergencyPlanDto>>(entities);
    }
}