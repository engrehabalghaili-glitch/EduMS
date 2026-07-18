using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMentors;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeMentors;

public class GetEmployeeMentorByIdQuery : IRequest<EmployeeMentorDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeMentorsQuery : IRequest<IEnumerable<EmployeeMentorDto>>
{
}