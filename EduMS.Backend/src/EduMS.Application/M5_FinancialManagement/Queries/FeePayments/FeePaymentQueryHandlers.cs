using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.FeePayments;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeePayments;

public class FeePaymentQueryHandlers : 
    IRequestHandler<GetFeePaymentByIdQuery, FeePaymentDto>,
    IRequestHandler<GetAllFeePaymentsQuery, IEnumerable<FeePaymentDto>>
{
    private readonly IGenericRepository<FeePayment> _repository;
    private readonly IMapper _mapper;

    public FeePaymentQueryHandlers(IGenericRepository<FeePayment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<FeePaymentDto> Handle(GetFeePaymentByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"FeePayment not found.");
        return _mapper.Map<FeePaymentDto>(entity);
    }

    public async Task<IEnumerable<FeePaymentDto>> Handle(GetAllFeePaymentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FeePaymentDto>>(entities);
    }
}