using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInternalTransfers;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeInternalTransfers;

public class CreateEmployeeInternalTransferCommand : IRequest<long>
{
    public CreateEmployeeInternalTransferDto Dto { get; set; } = new();
}

public class UpdateEmployeeInternalTransferCommand : IRequest<bool>
{
    public UpdateEmployeeInternalTransferDto Dto { get; set; } = new();
}

public class DeleteEmployeeInternalTransferCommand : IRequest<bool>
{
    public long Id { get; set; }
}