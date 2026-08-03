using EduMS.Application.M5_FinancialManagement.DTOs.InvoiceItems;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.InvoiceItems;

public class CreateInvoiceItemCommand : IRequest<long>
{
    public CreateInvoiceItemDto Dto { get; set; } = new();
}

public class UpdateInvoiceItemCommand : IRequest<bool>
{
    public UpdateInvoiceItemDto Dto { get; set; } = new();
}

public class DeleteInvoiceItemCommand : IRequest<bool>
{
    public long Id { get; set; }
}