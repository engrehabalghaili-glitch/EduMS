using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMeetings;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeMeetings;

public class GetEmployeeMeetingByIdQuery : IRequest<EmployeeMeetingDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeMeetingsQuery : IRequest<IEnumerable<EmployeeMeetingDto>>
{
}