using EduMS.Application.M5_FinancialManagement.DTOs.FeePayments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeePayments;

public class GetFeePaymentByIdQuery : IRequest<FeePaymentDto>
{
    public long Id { get; set; }
}

public class GetAllFeePaymentsQuery : IRequest<IEnumerable<FeePaymentDto>>
{
}