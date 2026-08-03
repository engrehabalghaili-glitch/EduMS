using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.InventoryPlans;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.InventoryPlans;

public class InventoryPlanQueryHandlers : 
    IRequestHandler<GetInventoryPlanByIdQuery, InventoryPlanDto>,
    IRequestHandler<GetAllInventoryPlansQuery, IEnumerable<InventoryPlanDto>>
{
    private readonly IGenericRepository<InventoryPlan> _repository;
    private readonly IMapper _mapper;

    public InventoryPlanQueryHandlers(IGenericRepository<InventoryPlan> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<InventoryPlanDto> Handle(GetInventoryPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"InventoryPlan not found.");
        return _mapper.Map<InventoryPlanDto>(entity);
    }

    public async Task<IEnumerable<InventoryPlanDto>> Handle(GetAllInventoryPlansQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<InventoryPlanDto>>(entities);
    }
}