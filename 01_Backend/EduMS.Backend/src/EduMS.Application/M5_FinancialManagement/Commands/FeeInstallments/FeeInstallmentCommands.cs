using EduMS.Application.M5_FinancialManagement.DTOs.FeeInstallments;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeInstallments;

public class CreateFeeInstallmentCommand : IRequest<long>
{
    public CreateFeeInstallmentDto Dto { get; set; } = new();
}

public class UpdateFeeInstallmentCommand : IRequest<bool>
{
    public UpdateFeeInstallmentDto Dto { get; set; } = new();
}

public class DeleteFeeInstallmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}