using EduMS.Application.M5_FinancialManagement.DTOs.FeeTypes;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeTypes;

public class CreateFeeTypeCommand : IRequest<long>
{
    public CreateFeeTypeDto Dto { get; set; } = new();
}

public class UpdateFeeTypeCommand : IRequest<bool>
{
    public UpdateFeeTypeDto Dto { get; set; } = new();
}

public class DeleteFeeTypeCommand : IRequest<bool>
{
    public long Id { get; set; }
}