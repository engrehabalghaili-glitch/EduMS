using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.FeeInvoices;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeInvoices;

public class FeeInvoiceQueryHandlers : 
    IRequestHandler<GetFeeInvoiceByIdQuery, FeeInvoiceDto>,
    IRequestHandler<GetAllFeeInvoicesQuery, IEnumerable<FeeInvoiceDto>>
{
    private readonly IGenericRepository<FeeInvoice> _repository;
    private readonly IMapper _mapper;

    public FeeInvoiceQueryHandlers(IGenericRepository<FeeInvoice> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FeeInvoiceDto> Handle(GetFeeInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FeeInvoice not found.");
        return _mapper.Map<FeeInvoiceDto>(entity);
    }

    public async Task<IEnumerable<FeeInvoiceDto>> Handle(GetAllFeeInvoicesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FeeInvoiceDto>>(entities);
    }
}