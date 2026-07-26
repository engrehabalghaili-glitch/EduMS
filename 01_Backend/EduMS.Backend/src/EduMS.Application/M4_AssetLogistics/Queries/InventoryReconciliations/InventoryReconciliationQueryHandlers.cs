using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.InventoryReconciliations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.InventoryReconciliations;

public class InventoryReconciliationQueryHandlers : 
    IRequestHandler<GetInventoryReconciliationByIdQuery, InventoryReconciliationDto>,
    IRequestHandler<GetAllInventoryReconciliationsQuery, IEnumerable<InventoryReconciliationDto>>
{
    private readonly IGenericRepository<InventoryReconciliation> _repository;
    private readonly IMapper _mapper;

    public InventoryReconciliationQueryHandlers(IGenericRepository<InventoryReconciliation> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<InventoryReconciliationDto> Handle(GetInventoryReconciliationByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"InventoryReconciliation not found.");
        return _mapper.Map<InventoryReconciliationDto>(entity);
    }

    public async Task<IEnumerable<InventoryReconciliationDto>> Handle(GetAllInventoryReconciliationsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<InventoryReconciliationDto>>(entities);
    }
}