using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrolls;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeePayrolls;

public class CreateEmployeePayrollCommand : IRequest<long>
{
    public CreateEmployeePayrollDto Dto { get; set; } = new();
}

public class UpdateEmployeePayrollCommand : IRequest<bool>
{
    public UpdateEmployeePayrollDto Dto { get; set; } = new();
}

public class DeleteEmployeePayrollCommand : IRequest<bool>
{
    public long Id { get; set; }
}