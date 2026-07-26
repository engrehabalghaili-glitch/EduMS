using EduMS.Application.M5_FinancialManagement.DTOs.PaymentVouchers;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.PaymentVouchers;

public class GetPaymentVoucherByIdQuery : IRequest<PaymentVoucherDto>
{
    public long Id { get; set; }
}

public class GetAllPaymentVouchersQuery : IRequest<IEnumerable<PaymentVoucherDto>>
{
}