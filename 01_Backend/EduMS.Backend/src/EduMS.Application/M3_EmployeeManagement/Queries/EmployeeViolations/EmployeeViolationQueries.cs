using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeViolations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeViolations;

public class GetEmployeeViolationByIdQuery : IRequest<EmployeeViolationDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeViolationsQuery : IRequest<IEnumerable<EmployeeViolationDto>>
{
}