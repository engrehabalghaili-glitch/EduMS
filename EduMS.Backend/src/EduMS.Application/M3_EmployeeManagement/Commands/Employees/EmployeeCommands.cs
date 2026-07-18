using EduMS.Application.M3_EmployeeManagement.DTOs.Employees;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.Employees;

public class CreateEmployeeCommand : IRequest<long>
{
    public CreateEmployeeDto Dto { get; set; } = new();
}

public class UpdateEmployeeCommand : IRequest<bool>
{
    public UpdateEmployeeDto Dto { get; set; } = new();
}

public class DeleteEmployeeCommand : IRequest<bool>
{
    public long Id { get; set; }
}