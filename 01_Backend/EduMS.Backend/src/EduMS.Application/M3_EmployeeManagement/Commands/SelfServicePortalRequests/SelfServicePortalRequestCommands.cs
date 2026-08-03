using EduMS.Application.M3_EmployeeManagement.DTOs.SelfServicePortalRequests;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.SelfServicePortalRequests;

public class CreateSelfServicePortalRequestCommand : IRequest<long>
{
    public CreateSelfServicePortalRequestDto Dto { get; set; } = new();
}

public class UpdateSelfServicePortalRequestCommand : IRequest<bool>
{
    public UpdateSelfServicePortalRequestDto Dto { get; set; } = new();
}

public class DeleteSelfServicePortalRequestCommand : IRequest<bool>
{
    public long Id { get; set; }
}