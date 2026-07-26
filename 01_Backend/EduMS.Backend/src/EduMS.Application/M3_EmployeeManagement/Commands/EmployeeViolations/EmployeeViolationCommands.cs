using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeViolations;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeViolations;

public class CreateEmployeeViolationCommand : IRequest<long>
{
    public CreateEmployeeViolationDto Dto { get; set; } = new();
}

public class UpdateEmployeeViolationCommand : IRequest<bool>
{
    public UpdateEmployeeViolationDto Dto { get; set; } = new();
}

public class DeleteEmployeeViolationCommand : IRequest<bool>
{
    public long Id { get; set; }
}