using EduMS.Application.M5_FinancialManagement.DTOs.FeePayments;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeePayments;

public class CreateFeePaymentCommand : IRequest<long>
{
    public CreateFeePaymentDto Dto { get; set; } = new();
}

public class UpdateFeePaymentCommand : IRequest<bool>
{
    public UpdateFeePaymentDto Dto { get; set; } = new();
}

public class DeleteFeePaymentCommand : IRequest<bool>
{
    public long Id { get; set; }
}