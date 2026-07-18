using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTerminations;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeTerminations;

public class CreateEmployeeTerminationCommand : IRequest<long>
{
    public CreateEmployeeTerminationDto Dto { get; set; } = new();
}

public class UpdateEmployeeTerminationCommand : IRequest<bool>
{
    public UpdateEmployeeTerminationDto Dto { get; set; } = new();
}

public class DeleteEmployeeTerminationCommand : IRequest<bool>
{
    public long Id { get; set; }
}