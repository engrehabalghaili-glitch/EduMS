using EduMS.Application.M3_EmployeeManagement.DTOs.OrganizationalSectors;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.OrganizationalSectors;

public class GetOrganizationalSectorByIdQuery : IRequest<OrganizationalSectorDto>
{
    public long Id { get; set; }
}

public class GetAllOrganizationalSectorsQuery : IRequest<IEnumerable<OrganizationalSectorDto>>
{
}