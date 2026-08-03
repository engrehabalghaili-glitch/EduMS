using EduMS.Application.M5_FinancialManagement.DTOs.InvoiceItems;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M5_FinancialManagement.Queries.InvoiceItems;

public class GetInvoiceItemByIdQuery : IRequest<InvoiceItemDto>
{
    public long Id { get; set; }
}

public class GetAllInvoiceItemsQuery : IRequest<IEnumerable<InvoiceItemDto>>
{
}