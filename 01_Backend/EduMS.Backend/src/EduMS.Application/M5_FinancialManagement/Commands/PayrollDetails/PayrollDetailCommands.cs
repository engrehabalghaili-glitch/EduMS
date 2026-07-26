using EduMS.Application.M5_FinancialManagement.DTOs.PayrollDetails;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.PayrollDetails;

public class CreatePayrollDetailCommand : IRequest<long>
{
    public CreatePayrollDetailDto Dto { get; set; } = new();
}

public class UpdatePayrollDetailCommand : IRequest<bool>
{
    public UpdatePayrollDetailDto Dto { get; set; } = new();
}

public class DeletePayrollDetailCommand : IRequest<bool>
{
    public long Id { get; set; }
}