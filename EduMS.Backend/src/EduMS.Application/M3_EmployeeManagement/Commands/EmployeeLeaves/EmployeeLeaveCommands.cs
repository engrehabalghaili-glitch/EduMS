using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeLeaves;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeLeaves;

public class CreateEmployeeLeaveCommand : IRequest<long>
{
    public CreateEmployeeLeaveDto Dto { get; set; } = new();
}

public class UpdateEmployeeLeaveCommand : IRequest<bool>
{
    public UpdateEmployeeLeaveDto Dto { get; set; } = new();
}

public class DeleteEmployeeLeaveCommand : IRequest<bool>
{
    public long Id { get; set; }
}