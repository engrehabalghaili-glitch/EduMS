using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTrainings;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeTrainings;

public class CreateEmployeeTrainingCommand : IRequest<long>
{
    public CreateEmployeeTrainingDto Dto { get; set; } = new();
}

public class UpdateEmployeeTrainingCommand : IRequest<bool>
{
    public UpdateEmployeeTrainingDto Dto { get; set; } = new();
}

public class DeleteEmployeeTrainingCommand : IRequest<bool>
{
    public long Id { get; set; }
}