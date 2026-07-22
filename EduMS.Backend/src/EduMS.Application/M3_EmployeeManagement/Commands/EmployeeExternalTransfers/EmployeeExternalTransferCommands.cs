using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeExternalTransfers;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeExternalTransfers;

public class CreateEmployeeExternalTransferCommand : IRequest<long>
{
    public CreateEmployeeExternalTransferDto Dto { get; set; } = new();
}

public class UpdateEmployeeExternalTransferCommand : IRequest<bool>
{
    public UpdateEmployeeExternalTransferDto Dto { get; set; } = new();
}

public class DeleteEmployeeExternalTransferCommand : IRequest<bool>
{
    public long Id { get; set; }
}