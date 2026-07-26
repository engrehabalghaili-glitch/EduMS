using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInventoryCustodies;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeInventoryCustodies;

public class CreateEmployeeInventoryCustodyCommand : IRequest<long>
{
    public CreateEmployeeInventoryCustodyDto Dto { get; set; } = new();
}

public class UpdateEmployeeInventoryCustodyCommand : IRequest<bool>
{
    public UpdateEmployeeInventoryCustodyDto Dto { get; set; } = new();
}

public class DeleteEmployeeInventoryCustodyCommand : IRequest<bool>
{
    public long Id { get; set; }
}