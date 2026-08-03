using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeMeetings;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeMeetings;

public class CreateEmployeeMeetingCommand : IRequest<long>
{
    public CreateEmployeeMeetingDto Dto { get; set; } = new();
}

public class UpdateEmployeeMeetingCommand : IRequest<bool>
{
    public UpdateEmployeeMeetingDto Dto { get; set; } = new();
}

public class DeleteEmployeeMeetingCommand : IRequest<bool>
{
    public long Id { get; set; }
}