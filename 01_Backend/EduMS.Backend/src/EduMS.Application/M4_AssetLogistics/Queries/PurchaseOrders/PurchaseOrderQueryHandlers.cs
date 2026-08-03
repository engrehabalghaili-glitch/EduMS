using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M4_AssetLogistics.DTOs.PurchaseOrders;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M4_AssetLogistics.Queries.PurchaseOrders;

public class PurchaseOrderQueryHandlers : 
    IRequestHandler<GetPurchaseOrderByIdQuery, PurchaseOrderDto>,
    IRequestHandler<GetAllPurchaseOrdersQuery, IEnumerable<PurchaseOrderDto>>
{
    private readonly IGenericRepository<PurchaseOrder> _repository;
    private readonly IMapper _mapper;

    public PurchaseOrderQueryHandlers(IGenericRepository<PurchaseOrder> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PurchaseOrderDto> Handle(GetPurchaseOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PurchaseOrder not found.");
        return _mapper.Map<PurchaseOrderDto>(entity);
    }

    public async Task<IEnumerable<PurchaseOrderDto>> Handle(GetAllPurchaseOrdersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PurchaseOrderDto>>(entities);
    }
}