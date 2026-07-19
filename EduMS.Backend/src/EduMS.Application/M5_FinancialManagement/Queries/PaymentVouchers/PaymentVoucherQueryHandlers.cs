using AutoMapper;
using EduMS.Application.Interfaces.Repositories.Common;
using EduMS.Domain.Entities;
using EduMS.Application.M5_FinancialManagement.DTOs.PaymentVouchers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Application.M5_FinancialManagement.Queries.PaymentVouchers;

public class PaymentVoucherQueryHandlers : 
    IRequestHandler<GetPaymentVoucherByIdQuery, PaymentVoucherDto>,
    IRequestHandler<GetAllPaymentVouchersQuery, IEnumerable<PaymentVoucherDto>>
{
    private readonly IGenericRepository<PaymentVoucher> _repository;
    private readonly IMapper _mapper;

    public PaymentVoucherQueryHandlers(IGenericRepository<PaymentVoucher> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaymentVoucherDto> Handle(GetPaymentVoucherByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) throw new KeyNotFoundException($"PaymentVoucher not found.");
        return _mapper.Map<PaymentVoucherDto>(entity);
    }

    public async Task<IEnumerable<PaymentVoucherDto>> Handle(GetAllPaymentVouchersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<PaymentVoucherDto>>(entities);
    }
}