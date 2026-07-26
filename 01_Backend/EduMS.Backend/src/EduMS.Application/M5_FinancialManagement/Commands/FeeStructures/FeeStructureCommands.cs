using EduMS.Application.M5_FinancialManagement.DTOs.FeeStructures;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeStructures;

public class CreateFeeStructureCommand : IRequest<long>
{
    public CreateFeeStructureDto Dto { get; set; } = new();
}

public class UpdateFeeStructureCommand : IRequest<bool>
{
    public UpdateFeeStructureDto Dto { get; set; } = new();
}

public class DeleteFeeStructureCommand : IRequest<bool>
{
    public long Id { get; set; }
}