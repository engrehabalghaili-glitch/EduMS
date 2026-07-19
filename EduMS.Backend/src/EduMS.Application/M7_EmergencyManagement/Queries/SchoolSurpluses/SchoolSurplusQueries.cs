using EduMS.Application.M7_EmergencyManagement.DTOs.SchoolSurpluses;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.SchoolSurpluses;

public class GetSchoolSurplusByIdQuery : IRequest<SchoolSurplusDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolSurplusesQuery : IRequest<IEnumerable<SchoolSurplusDto>>
{
}