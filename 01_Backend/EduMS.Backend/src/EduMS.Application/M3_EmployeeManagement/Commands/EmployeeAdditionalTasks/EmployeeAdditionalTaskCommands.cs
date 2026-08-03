using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAdditionalTasks;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeAdditionalTasks;

public class CreateEmployeeAdditionalTaskCommand : IRequest<long>
{
    public CreateEmployeeAdditionalTaskDto Dto { get; set; } = new();
}

public class UpdateEmployeeAdditionalTaskCommand : IRequest<bool>
{
    public UpdateEmployeeAdditionalTaskDto Dto { get; set; } = new();
}

public class DeleteEmployeeAdditionalTaskCommand : IRequest<bool>
{
    public long Id { get; set; }
}