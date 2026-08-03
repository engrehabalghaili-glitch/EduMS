using EduMS.Application.M5_FinancialManagement.DTOs.FeeInvoices;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.FeeInvoices;

public class GetFeeInvoiceByIdQuery : IRequest<FeeInvoiceDto>
{
    public long Id { get; set; }
}

public class GetAllFeeInvoicesQuery : IRequest<IEnumerable<FeeInvoiceDto>>
{
}