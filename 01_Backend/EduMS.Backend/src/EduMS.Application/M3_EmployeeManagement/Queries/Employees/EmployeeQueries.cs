using EduMS.Application.M3_EmployeeManagement.DTOs.Employees;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.Employees;

public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
{
}