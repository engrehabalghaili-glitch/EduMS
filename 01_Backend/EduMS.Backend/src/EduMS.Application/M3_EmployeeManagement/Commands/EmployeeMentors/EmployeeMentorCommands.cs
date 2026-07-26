using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMentors;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeMentors;

public class CreateEmployeeMentorCommand : IRequest<long>
{
    public CreateEmployeeMentorDto Dto { get; set; } = new();
}

public class UpdateEmployeeMentorCommand : IRequest<bool>
{
    public UpdateEmployeeMentorDto Dto { get; set; } = new();
}

public class DeleteEmployeeMentorCommand : IRequest<bool>
{
    public long Id { get; set; }
}