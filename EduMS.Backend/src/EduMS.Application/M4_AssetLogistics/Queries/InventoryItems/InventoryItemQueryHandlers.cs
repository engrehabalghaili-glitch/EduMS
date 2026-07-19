using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.InventoryItems;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.InventoryItems;

public class InventoryItemQueryHandlers : 
    IRequestHandler<GetInventoryItemByIdQuery, InventoryItemDto>,
    IRequestHandler<GetAllInventoryItemsQuery, IEnumerable<InventoryItemDto>>
{
    private readonly IGenericRepository<InventoryItem> _repository;
    private readonly IMapper _mapper;

    public InventoryItemQueryHandlers(IGenericRepository<InventoryItem> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<InventoryItemDto> Handle(GetInventoryItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"InventoryItem not found.");
        return _mapper.Map<InventoryItemDto>(entity);
    }

    public async Task<IEnumerable<InventoryItemDto>> Handle(GetAllInventoryItemsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<InventoryItemDto>>(entities);
    }
}