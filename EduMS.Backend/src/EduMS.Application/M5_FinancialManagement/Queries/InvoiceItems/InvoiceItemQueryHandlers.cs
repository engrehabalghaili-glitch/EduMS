using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.InvoiceItems;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.InvoiceItems;

public class InvoiceItemQueryHandlers : 
    IRequestHandler<GetInvoiceItemByIdQuery, InvoiceItemDto>,
    IRequestHandler<GetAllInvoiceItemsQuery, IEnumerable<InvoiceItemDto>>
{
    private readonly IGenericRepository<InvoiceItem> _repository;
    private readonly IMapper _mapper;

    public InvoiceItemQueryHandlers(IGenericRepository<InvoiceItem> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<InvoiceItemDto> Handle(GetInvoiceItemByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"InvoiceItem not found.");
        return _mapper.Map<InvoiceItemDto>(entity);
    }

    public async Task<IEnumerable<InvoiceItemDto>> Handle(GetAllInvoiceItemsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<InvoiceItemDto>>(entities);
    }
}