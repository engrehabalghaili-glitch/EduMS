using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M7_EmergencyManagement.DTOs.RemediationPlans;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M7_EmergencyManagement.Queries.RemediationPlans;

public class RemediationPlanQueryHandlers : 
    IRequestHandler<GetRemediationPlanByIdQuery, RemediationPlanDto>,
    IRequestHandler<GetAllRemediationPlansQuery, IEnumerable<RemediationPlanDto>>
{
    private readonly IGenericRepository<RemediationPlan> _repository;
    private readonly IMapper _mapper;

    public RemediationPlanQueryHandlers(IGenericRepository<RemediationPlan> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RemediationPlanDto> Handle(GetRemediationPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"RemediationPlan not found.");
        return _mapper.Map<RemediationPlanDto>(entity);
    }

    public async Task<IEnumerable<RemediationPlanDto>> Handle(GetAllRemediationPlansQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<RemediationPlanDto>>(entities);
    }
}