using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrollFinancialContracts;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeePayrollFinancialContracts;

public class CreateEmployeePayrollFinancialContractCommand : IRequest<long>
{
    public CreateEmployeePayrollFinancialContractDto Dto { get; set; } = new();
}

public class UpdateEmployeePayrollFinancialContractCommand : IRequest<bool>
{
    public UpdateEmployeePayrollFinancialContractDto Dto { get; set; } = new();
}

public class DeleteEmployeePayrollFinancialContractCommand : IRequest<bool>
{
    public long Id { get; set; }
}