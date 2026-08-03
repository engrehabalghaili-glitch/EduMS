using EduMS.Application.M5_FinancialManagement.DTOs.PayrollRuns;
using MediatR;

namespace EduMS.Application.M5_FinancialManagement.Commands.PayrollRuns;

public class CreatePayrollRunCommand : IRequest<long>
{
    public CreatePayrollRunDto Dto { get; set; } = new();
}

public class UpdatePayrollRunCommand : IRequest<bool>
{
    public UpdatePayrollRunDto Dto { get; set; } = new();
}

public class DeletePayrollRunCommand : IRequest<bool>
{
    public long Id { get; set; }
}