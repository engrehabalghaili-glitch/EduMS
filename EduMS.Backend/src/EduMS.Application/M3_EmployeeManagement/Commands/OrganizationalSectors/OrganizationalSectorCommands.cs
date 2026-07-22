using EduMS.Application.M3_EmployeeManagement.DTOs.OrganizationalSectors;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.OrganizationalSectors;

public class CreateOrganizationalSectorCommand : IRequest<long>
{
    public CreateOrganizationalSectorDto Dto { get; set; } = new();
}

public class UpdateOrganizationalSectorCommand : IRequest<bool>
{
    public UpdateOrganizationalSectorDto Dto { get; set; } = new();
}

public class DeleteOrganizationalSectorCommand : IRequest<bool>
{
    public long Id { get; set; }
}