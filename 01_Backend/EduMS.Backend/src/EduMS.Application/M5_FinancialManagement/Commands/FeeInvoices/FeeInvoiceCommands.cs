using EduMS.Application.M5_FinancialManagement.DTOs.FeeInvoices;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeInvoices;

public class CreateFeeInvoiceCommand : IRequest<long>
{
    public CreateFeeInvoiceDto Dto { get; set; } = new();
}

public class UpdateFeeInvoiceCommand : IRequest<bool>
{
    public UpdateFeeInvoiceDto Dto { get; set; } = new();
}

public class DeleteFeeInvoiceCommand : IRequest<bool>
{
    public long Id { get; set; }
}