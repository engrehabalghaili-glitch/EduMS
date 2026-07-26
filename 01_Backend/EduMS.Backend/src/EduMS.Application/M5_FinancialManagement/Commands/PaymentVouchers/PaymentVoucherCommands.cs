using EduMS.Application.M5_FinancialManagement.DTOs.PaymentVouchers;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.PaymentVouchers;

public class CreatePaymentVoucherCommand : IRequest<long>
{
    public CreatePaymentVoucherDto Dto { get; set; } = new();
}

public class UpdatePaymentVoucherCommand : IRequest<bool>
{
    public UpdatePaymentVoucherDto Dto { get; set; } = new();
}

public class DeletePaymentVoucherCommand : IRequest<bool>
{
    public long Id { get; set; }
}