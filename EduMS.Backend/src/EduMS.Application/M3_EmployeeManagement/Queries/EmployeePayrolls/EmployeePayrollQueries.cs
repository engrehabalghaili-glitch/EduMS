using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeePayrolls;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeePayrolls;

public class GetEmployeePayrollByIdQuery : IRequest<EmployeePayrollDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeePayrollsQuery : IRequest<IEnumerable<EmployeePayrollDto>>
{
}